﻿using System;
using EDD.Models;

using System.Collections.Generic;

namespace EDD.Functions
{
    public class GetDomainComputers : EDDFunction
    {
        public override string FunctionName => "GetDomainComputers";

        public override string[] Execute(ParsedArgs args)
        {
            try
            {
                List<string> domainComputers = new List<string>();
                LDAP domainQuery = new LDAP();
                if (string.IsNullOrEmpty(args.DomainName))
                {
                    domainComputers = domainQuery.CaptureComputers();
                }
                else
                {
                    domainComputers = domainQuery.CaptureComputers(args.DomainName);
                }
                return domainComputers.ToArray();
            }
            catch (Exception e)
            {
                return new string[] { "[X] Failure to enumerate info - " + e };
            }
        }
    }
}
