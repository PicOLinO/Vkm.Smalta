﻿#region Usings

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Network;
using Vkm.ComplexSim.Services;

#endregion

namespace Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories
{
    public class NetworkServiceStub : INetworkService
    {
        public bool BoolDialogResult { get; set; }
        public bool ExamineResultSendedToAdmin { get; private set; }

        #region INetworkService

        public Task<Student> Authorize(NetworkCredential credential)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamWithStudentsWithoutLoginsDto>> GetTeamsAndStudentsWithoutLogin()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterDataDto registerData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendExamineResultToAdmin(ExamineResult examineResult)
        {
            ExamineResultSendedToAdmin = true;
            return Task.FromResult(BoolDialogResult);
        }

        #endregion
    }
}