using Newtonsoft.Json;
using System.Collections.Generic;

namespace Smn.Response.Sms
{
    ///<summary> 
    /// list sms templates response message
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class ListSmsTemplatesResponse : BaseResponse
    {
        /// <summary>
        /// count
        /// </summary>
        private int count;

        /// <summary>
        /// sms_templates
        /// </summary>
        private List<SmsTemplate> smsTemplates;

        [JsonProperty("count")]
        public int Count { get => count; set => count = value; }
        [JsonProperty("sms_templates")]
        public List<SmsTemplate> SmsTemplates { get => smsTemplates; set => smsTemplates = value; }
    }

    ///<summary> 
    /// sms template info
    /// author:zhangyx
    /// version:1.0.1
    ///</summary> 
    public class SmsTemplate
    {
        /// <summary>
        /// sms template name
        /// </summary>
        private string smsTemplateName;

        /// <summary>
        /// sms template type
        /// </summary>
        private int smsTemplateType;

        /// <summary>
        /// sms template id
        /// </summary>
        private string smsTemplateId;

        /// <summary>
        /// reply
        /// </summary>
        private string reply;

        /// <summary>
        /// status
        /// </summary>
        private int status;

        /// <summary>
        /// create time
        /// </summary>
        private string createTime;

        /// <summary>
        /// validity end time
        /// </summary>
        private string validityEndTime;

        [JsonProperty("sms_template_name")]
        public string SmsTemplateName { get => smsTemplateName; set => smsTemplateName = value; }
        [JsonProperty("sms_template_type")]
        public int SmsTemplateType { get => smsTemplateType; set => smsTemplateType = value; }
        [JsonProperty("sms_template_id")]
        public string SmsTemplateId { get => smsTemplateId; set => smsTemplateId = value; }
        [JsonProperty("reply")]
        public string Reply { get => reply; set => reply = value; }
        [JsonProperty("status")]
        public int Status { get => status; set => status = value; }
        [JsonProperty("create_time")]
        public string CreateTime { get => createTime; set => createTime = value; }
        [JsonProperty("validity_end_time")]
        public string ValidityEndTime { get => validityEndTime; set => validityEndTime = value; }
    }
}
