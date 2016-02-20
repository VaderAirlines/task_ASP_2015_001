function validateForm(wrapperClass) {
	var fields = [
		{
			id: 'txtUsername',
			checks: [
						{ required: true },
						{ maxLength: 5 }
			],
			messages: {
				required: "gelieve dit veld in te vullen",
				maxLength: "dit veld mag niet meer dan 5 karakters bevatten"
			}

		},
		{
			id: 'txtPassword',
			checks: [
						{ maxLength: 5 }
			],
			messages: {
				maxLength: "dit veld mag niet meer dan 5 karakters bevatten"
			}

		}
	];

	return validateFields(wrapperClass, fields);
};
 
function validateFields(wrapperClass, fields, messages) {
	var returnValues = [];

	for (i = 0; i < fields.length; i++) {
		var field = fields[i];

		for (j = 0; j < field.checks.length; j++) {
			var check = field.checks[j];

			for (var key in check) {
				var $element = getElementOnId(wrapperClass, field.id);
				var returnValue = window[key]($element, check[key]);

				if (!returnValue) {
					$element.after('<div class="error-message">' + field.messages[key] + '</div>');
				};

				returnValues.push(returnValue);
			}
		}
	}

	return returnValues.indexOf(false) > -1 ? false : true;
};

// checker helpers
function getElementOnId(wrapperClass, elementId) {
	return $('.' + wrapperClass).find('#' + elementId);
}

// checkers
function required($element) {
	if (maxLength($element)) return true;
	return false;
}

function maxLength($element, length) {
	var $val = $element.val();
	if ($val.length < length) return true;
	return false;
}