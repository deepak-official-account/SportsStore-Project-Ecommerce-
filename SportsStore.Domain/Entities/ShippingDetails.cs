using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore.Domain.Entities
{
	public class ShippingDetails
	{
		[Required(ErrorMessage ="Please Enter Valid Name")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public string Address	{ get; set; }

        [Required(ErrorMessage = "Please Enter Valid City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Valid State")]
        public string State {  get; set; }

        [Required(ErrorMessage = "Please Enter Valid PinCode")]
        public string PinCode {  get; set; }

        [Required(ErrorMessage = "Please Enter Valid Country name")]
        public string  Country { get; set; }

	}
}