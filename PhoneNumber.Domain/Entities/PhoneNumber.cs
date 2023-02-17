using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneNumber.Domain.Entities
{
	public class PhoneNumber
	{
		[Key]
		public long Id { get; set; }
		[Display(Name = "Name")]
		[Required(ErrorMessage = "{0} is required")]
		public string Name { get; set; }
		[Display(Name = "Family")]
		[Required(ErrorMessage = "{0} is required")]
		public string Family { get; set; }
		[Display(Name = "Phone")]
		[Required(ErrorMessage = "{0} is required")]
		public string Phone { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Display(Name = "Address")]
		public string Address { get; set; }

		public bool IsDelete { get; set; }

	}
}
