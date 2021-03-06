﻿using GMS_System.Model;
using System.Collections.Generic;

namespace GMS_System.Interface
{
    public interface ITemplate
    {
        List<Template> getTemplateForNote(int IssueTypeId, int TenantID);

        Template getTemplateContent(int TemplateId, int TenantId);

        #region Settings Template
        int InsertTemplate(int tenantId, string TemplateName, string TemplatSubject, string TemplatBody, string issueTypes, bool isTemplateActive, int createdBy);

        int DeleteTemplate(int tenantID, int TemplateID);

        int UpdateTemplate(int tenantId, int TemplateID, string TemplateName, string issueType, bool isTemplateActive, int ModifiedBy, string templateSubject, string templateContent);

        List<TemplateModel> GetTemplates(int tenantId );

        List<MailParameterModel> GetMailParameter(int tenantId, int AlertID);


        #endregion
    }
}
