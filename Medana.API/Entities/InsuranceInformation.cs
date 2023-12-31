﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

[ComplexType]
public class InsuranceInformation
{
    public string InsuranceProvider { get; set; }

    public string InsurancePolicyNumber { get; set; }
}

