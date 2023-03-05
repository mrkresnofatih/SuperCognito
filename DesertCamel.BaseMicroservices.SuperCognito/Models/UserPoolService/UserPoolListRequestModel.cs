﻿using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.UserPoolService
{
    public class UserPoolListRequestModel
    {
        public string Name { get; set; }
        [Required]
        public long PageSize { get; set; }
        [Required]
        public long Page { get; set; }
    }
}
