using System.Collections.Generic;
using System.Threading;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Stc.AppTemplate.Wizard
{
    public class SafeProjectGroupName : IWizard
    {
        public const string ParameterName = "$safeprojectgroupname$";

        static ThreadLocal<string> projectGroupName = new ThreadLocal<string>();
        bool isRootWizard;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
            // If we were the ones to set the value, we must clear it.
            if (isRootWizard)
                projectGroupName.Value = null;
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            if (projectGroupName.Value == null)
            {
                projectGroupName.Value = replacementsDictionary["$safeprojectname$"];
                // If there wasn't a value already, it means we're the root wizard itself.
                isRootWizard = true;
            }

            replacementsDictionary[ParameterName] = projectGroupName.Value;
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
