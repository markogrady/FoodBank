using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Dto.Submission;

namespace FoodBank.Core.Business.Submission
{
    public interface ISubmissionBusiness
    {
        Task<Guid> Create(SubmissionCreateModel model);

        Task<SubmissionEditModel> GetSubmission(Guid id);

        Task ValidateSubmission(Guid id);

        Task CompleteSubmission(Guid id);
    }

    public class SubmissionBusiness :ISubmissionBusiness
    {
        private IAppDbContext _appDbContext;

        public SubmissionBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(SubmissionCreateModel model)
        {
            var id = Guid.NewGuid();
            var submission = new Data.Model.Submission();
            submission.SubmissionId = id;
            submission.FileName = model.FileName;
            submission.Reference = model.Reference;
            submission.SubmissionStatus = SubmissionStatus.Uploaded;
            submission.LocationUrl = model.LocationUrl;
            submission.CreationDate = DateTime.UtcNow;

            _appDbContext.Submissions.Add(submission);
            await _appDbContext.SaveChangesAsync();
            return id;
        }

        public async Task<SubmissionEditModel> GetSubmission(Guid id)
        {
            var model = new SubmissionEditModel();

            var submission = await _appDbContext.Submissions.FirstOrDefaultAsync(o => o.SubmissionId == id);

            if (submission != null)
            {
                model.SubmissionId = submission.SubmissionId;
                model.FileName = submission.FileName;
                model.LocationUrl = submission.LocationUrl;
                model.Reference = submission.Reference;
                model.SubmissionStatus = submission.SubmissionStatus;
                model.CreationDate = submission.CreationDate;
            }


            return model;
        }

        public async Task ValidateSubmission(Guid id)
        {
            var submission = await _appDbContext.Submissions.FirstOrDefaultAsync(o => o.SubmissionId == id);

            if (submission != null)
            {
                //do some validation
                var error = "";
                if (String.IsNullOrEmpty(error))
                {
                    submission.SubmissionStatus = SubmissionStatus.Validated;
                }
                else
                {
                    submission.JsonErrorPayload = error;
                    submission.SubmissionStatus = SubmissionStatus.Error;
                }

                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task CompleteSubmission(Guid id)
        {
            var submission = await _appDbContext.Submissions.FirstOrDefaultAsync(o => o.SubmissionId == id);

            if (submission != null)
            {
                //do some validation
                var error = "";
                if (String.IsNullOrEmpty(error))
                {
                    submission.SubmissionStatus = SubmissionStatus.Completed;
                }
                else
                {
                    submission.JsonErrorPayload = error;
                    submission.SubmissionStatus = SubmissionStatus.Error;
                }

                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}