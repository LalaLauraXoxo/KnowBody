using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASI.Basecode.WebApp.Models
{
    /// <summary>
    /// Select Dropdown List Model
    /// </summary>
    public class SelectListItem
    {
        /// <summary>
        /// SelectListItem default constructor
        /// </summary>
        public SelectListItem()
        {
        }

        /// <summary>
        /// Populates Select List Item 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public SelectListItem(string text = "", string value = "")
        {
            this.Label = text;
            this.Value = value;
        }

        /// <summary>
        /// Select dropdown item label
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Select dropdown item value
        /// </summary>
        public string Value { get; set; }

        public string BgColor { get; set; }
    }
}
