﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class AppRole:IdentityRole<int>
	{
		public ICollection<AppUserRole> UserRoles { get; set; }
	}
}
