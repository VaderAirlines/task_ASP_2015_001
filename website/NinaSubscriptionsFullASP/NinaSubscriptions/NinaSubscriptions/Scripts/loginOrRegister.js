$(function () {
	//$(".component-wrapper #txtUsername").mask("99/99/9999", { placeholder: "mm/dd/yyyy" });
});

function validateForm(wrapperClass) {
	var max50chars = "dit veld mag niet meer dan 50 karakters bevatten";
	var mustComplete = "gelieve dit veld in te vullen";

	var fields = [
		{
			id: 'txtUsername',
			checks: [
						{ required: true },
						{ maxLength: 50 },
			],
			messages: {
				required: mustComplete,
				maxLength: max50chars,
			}

		},
		{
			id: 'txtPassword',
			checks: [
						{ maxLength: 50 }
			],
			messages: {
				maxLength: max50chars
			}

		}
	];

	return validateFields(wrapperClass, fields);
};