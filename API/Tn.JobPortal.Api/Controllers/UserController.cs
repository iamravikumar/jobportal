﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tn.JobPortal.Api.Business;
using Tn.JobPortal.Api.Models;

namespace Tn.JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user business
        /// </summary>
        private IUserBusiness userBusiness;

        /// <summary>
        /// The configuration
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="_userBusiness">The user business.</param>
        public UserController(IUserBusiness _userBusiness, IConfiguration _configuration)
        {
            userBusiness = _userBusiness;
            Configuration = _configuration;
        }

        /// <summary>
        /// Gets the latest jobs posted.
        /// </summary>
        /// <returns></returns>
        [HttpGet("jobsposted/{userid?}")]
        public async Task<UserJobDetailsAndSearchStringsModel> GetLatestJobsAsync(string userId = null)
        {
            string postedByValues = Configuration["PostedBy"];
            return await userBusiness.GetLatestJobsAsync(postedByValues, userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the job search strings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchstrings")]
        public async Task<List<JobRolesModel>> GetJobSearchStringsAsync()
        {
            return await userBusiness.GetJobSearchStringsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the filtered jobs asynchronous.
        /// </summary>
        /// <param name="jobSearchString">The job search string.</param>
        /// <param name="filteredBy">The filtered by.</param>
        /// <returns></returns>
        [HttpPost("filter/jobs/{filteredBy}")]
        public async Task<List<JobDetailsModel>> GetFilteredJobsAsync(SearchQueryClientModel jobSearchString, string filteredBy)
        {
            string postedByValues = Configuration["PostedBy"];
            return await userBusiness.GetFilteredJobsAsync(jobSearchString.SearchQuery, filteredBy, postedByValues).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the or update job status.
        /// </summary>
        /// <param name="jobStatus">The job status.</param>
        /// <returns></returns>
        [HttpPost("update/job/status")]
        public async Task<bool> AddOrUpdateJobStatusAsync(JobStatusModel jobStatus)
        {
            return await userBusiness.AddOrUpdateJobStatusAsync(jobStatus).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the or update job roles asynchronous.
        /// </summary>
        /// <param name="jobRoles">The job roles.</param>
        /// <returns></returns>
        [HttpPost("update/job/roles")]
        public async Task<int> AddOrUpdateJobRolesAsync(JobRolesModel jobRoles)
        {
            return await userBusiness.AddOrUpdateJobRolesAsync(jobRoles).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the leader board details asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("leader/board")]
        public async Task<WeekAndDayLeaderBoard> GetLeaderBoardDetailsAsync()
        {
            return await userBusiness.GetLeaderBoardDetailsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all consultants asynchronous.
        /// </summary>
        /// <returns>all consultants</returns>
        [HttpGet("consultants")]
        public async Task<List<ConsultantsClientModel>> GetAllConsultantsAsync()
        {
            return await userBusiness.GetAllConsultantsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the or update consultants asynchronous.
        /// </summary>
        /// <param name="consultantData">The consultant data.</param>
        /// <returns>consultant id</returns>
        [HttpPost("consultant")]
        public async Task<int> AddOrUpdateConsultantsAsync(ConsultantsClientModel consultantData)
        {
            return await userBusiness.AddOrUpdateConsultantsAsync(consultantData.InsertedBy, consultantData).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the consultants asynchronous.
        /// </summary>
        /// <param name="consultantId">The consultant identifier.</param>
        /// <param name="updatedBy">The updated by.</param>
        /// <returns>response</returns>
        [HttpGet("consultant/{consultantId}/{updatedBy}")]
        public async Task<bool> DeleteConsultantsAsync(int consultantId, string updatedBy)
        {
            return await userBusiness.DeleteConsultantsAsync(consultantId, updatedBy).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all consultants and jobs for member asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>all consultants and jobs</returns>
        [HttpGet("all/consultants/jobs/{memberId}")]
        public async Task<ConsultantsAndJobs> GetAllConsultantsAndJobsForMemberAsync(string memberId)
        {
            return await userBusiness.GetAllConsultantsAndJobsForMemberAsync(memberId).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the selected consultant jobs for member.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <param name="consultantIdList">The consultant identifier list.</param>
        /// <returns>jobs</returns>
        [HttpPost("consultants/jobs/{memberId}")]
        public async Task<List<JobDetailsModel>> GetSelectedConsultantJobsForMember(string memberId, SearchQueryClientModel consultantIdList)
        {
            return await userBusiness.GetSelectedConsultantJobsForMember(memberId, consultantIdList.SearchQuery).ConfigureAwait(false);
        }
        
    }
}