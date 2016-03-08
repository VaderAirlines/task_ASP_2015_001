using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

		public void addValidationRule(customValidationRule rule) {
			this.rules.Add(rule);
		}

		// usable checker functions
		public bool required(Control control, string parameter) {
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

		public bool maxLength(Control control, string parameter) {
			if (control is TextBox) {
				if ((control as TextBox).Text.Length > Convert.ToInt32(parameter)) { return false; }
			} else { return false; }

			return true;
		}

		public bool email(Control control, string parameter) {
			if (control is TextBox) {
				return Regex.IsMatch(
					(control as TextBox).Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
			}

			return true;
		}

		public bool hour(Control control, string parameter) {
			if (control is TextBox) {
				return hour((control as TextBox).Text);
			}

			return false;
		}

		public bool hour(string value) {
			return Regex.IsMatch(value, @"^\d\d:\d\d$", RegexOptions.None);
		}

		public bool numeric(Control control, string parameter) {
			if (control is TextBox) {
				return Regex.IsMatch((control as TextBox).Text, @"^[+]?\d+$", RegexOptions.None);
			}

			return false;
		}

		public bool validDate(Control control, string parameter) {
			if (control is TextBox) {
				string val = (control as TextBox).Text;

				return validDate(val);
			}

			return false;
		}

		public bool validDate(string value) {
			if (!Regex.IsMatch(value, @"^\d\d\/\d\d\/\d\d\d\d$", RegexOptions.None))
				return false;

			string[] split = value.Split('/');
			int day = Convert.ToInt32(split[0]);
			int month = Convert.ToInt32(split[1]);
			int year = Convert.ToInt32(split[2]);

			try {
				DateTime date = new DateTime(year, month, day);
				return true;
			} catch {
				return false;
			}
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