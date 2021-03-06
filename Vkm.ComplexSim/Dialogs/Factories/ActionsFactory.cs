﻿#region Usings

using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Hints.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs.Factories
{
    public class ActionsFactory : IActionsFactory
    {
        #region IActionsFactory

        public Action GetClickAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = true)
        {
            return new Action(ActionName.Click, elementName, useInExamineCheck, new AccessibleHintViewModel(hint, accessibleValue));
        }

        public Action GetIdleAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = false)
        {
            return new Action(ActionName.Idle, elementName, useInExamineCheck, new AccessibleHintViewModel(hint, accessibleValue));
        }

        public Action GetInfoAction(string elementName, string hint, bool useInExamineCheck = false)
        {
            return new Action(ActionName.Idle, elementName, useInExamineCheck, new HintViewModelBase(hint));
        }

        #endregion
    }
}