using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Custom_validation {

	public class customValidator {
		// fields
		List<string> errors = new List<string>();
		List<customValidationRule> rules = new List<customValidationRule>();

		// public API
		internal List<string> validate() {
			foreach (customValidationRule rule in rules) {
				if (!rule.checker.Invoke(rule.control, rule.parameter)) {
					errors.Add(rule.message);
				}
			}

			return errors;
		}

		internal void addValidationRule(customValidationRule rule) {
			this.rules.Add(rule);
		}

		// usable checker functions
		internal bool required(Control control, string parameter) {
			if (control is TextBox) {
				if ((control as TextBox).Text.Length < 1) { 
					return false; 
				}
			} else if (control is DropDownList) {
				if ((control as DropDownList).SelectedIndex < 0) { 
					return false; 
				}
			} else {
				return false;
			}

			return true;
		}

		internal bool maxLength(Control control, string parameter) {
			if (control is TextBox) {
				if ((control as TextBox).Text.Length > Convert.ToInt32(parameter)) { return false; }
			} else { return false; }

			return true;
		}
	}

	public class customValidationRule {
		public customValidationRule(Control control, checkerDelegate del, string parameter, string message) {
			this.control = control;
			this.checker = del;
			this.parameter = parameter;
			this.message = message;
		}

		public Control control { get; set; }
		public checkerDelegate checker { get; set; }
		public string parameter { get; set; }
		public string message { get; set; }
	}

	public delegate bool checkerDelegate(Control control, string parameter);
}