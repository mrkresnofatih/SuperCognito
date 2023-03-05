﻿using System.ComponentModel.DataAnnotations;

namespace DesertCamel.BaseMicroservices.SuperCognito.Models.RoleService
{
    public class RoleCreateRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
