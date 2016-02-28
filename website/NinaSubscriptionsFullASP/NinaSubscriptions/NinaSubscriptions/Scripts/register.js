//$(function () {
//	$(".component-wrapper #txtUsername").mask("99/99/9999", { placeholder: "mm/dd/yyyy" });
//	$(".component-wrapper #txtPassword").mask("99:99", { placeholder: "hh:hh" });
//});

function validateForm(wrapperClass) {
	var max50chars = "dit veld mag niet meer dan 50 karakters bevatten";
	var mustComplete = "gelieve dit veld in te vullen";
	var giveEmail = "gelieve een geldig emailadres in te vullen";

	var fields = [
		{
			id: 'txtUsername',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtName',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtFirstName',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtEmailAddress',
			checks: [{ required: true }, { maxLength: 50 }, { email: true }],
			messages: {	required: mustComplete, maxLength: max50chars, email: giveEmail }
		},
		{
			id: 'txtPhone',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtStreet',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtNumber',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtPostalCode',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtPlace',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtPassword',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtPasswordRepeat',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: {	required: mustComplete, maxLength: max50chars }
		},
	];

	var retval = validateFields(wrapperClass, fields);

	return retval;
};