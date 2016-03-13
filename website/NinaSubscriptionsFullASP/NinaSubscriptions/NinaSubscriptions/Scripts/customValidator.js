// fields parameter example:
// var fields = [
//	{
//		id: 'txtUsername',
//		checks: [
//					{ required: true },
//					{ maxLength: 5 }
//		],
//		messages: {
//			required: "gelieve dit veld in te vullen",
//			maxLength: "dit veld mag niet meer dan 5 karakters bevatten"
//		}
//	},
//	{
//		id: 'txtPassword',
//		checks: [
//					{ maxLength: 5 }
//		],
//		messages: {
//			maxLength: "dit veld mag niet meer dan 5 karakters bevatten"
//		}
//	}
//];

// validates the given fields (on id, within the wrapper class) and if necessary displays the given messages
// param 1: wrapperclass (css class of wrapper element)
// param 2: object that includes the field id's, an array of check functions and their corresponding messages
function validateFields(wrapperClass, fields) {
	removeCurrentErrorMessages();

	var returnValues = [];

	for (i = 0; i < fields.length; i++) {
		var field = fields[i];

		for (j = 0; j < field.checks.length; j++) {
			var check = field.checks[j];

			for (var key in check) {
				var $element = getWrappedElementOnId(wrapperClass, field.id);
				var returnValue = this[key]($element, check[key]);

				if (!returnValue) {
					$element.after('<div class="error-message">' + field.messages[key] + '</div>');
					$element.addClass('has-error');
				};

				returnValues.push(returnValue);
			}
		}
	}

	return returnValues.indexOf(false) > -1 ? false : true;
};

// checker helpers
function getWrappedElementOnId(wrapperClass, elementId) {
	return $('.' + wrapperClass).find('#' + elementId);
}

// checkers
function required($element) {
	if ($element.val().length == 0) return false;
	return true;
}

function maxLength($element, length) {
	length = length || -1;
	var $val = $element.val();
	if ($val.length <= length) return true;
	return false;
}

function email($element) {
	return /[^\s@]+@[^\s@]+\.[^\s@]+/.test($element.val());
}

function validDate($element) {
	if (!/^\d\d\/\d\d\/\d\d\d\d$/.test($element.val())) return false;

	var split = $element.val().split('/');
	var day = split[0];
	var month = parseInt(split[1]) - 1;
	var year = split[2];
	
	try {
		var date = new Date(year, month, day, 0, 0, 0, 0);
		return true;
	} catch (e) {
		return false;
	}

	return false;
}

function hour($element) {
	return /^\d\d:\d\d$/.test($element.val());
}

function numeric($element) {
	if ($element.val() == '') return false;
	return /^[+]?\d+$/.test($element.val());
}

// error removers
function removeCurrentErrorMessages() {
	$('.error-message').remove();
	$(':input').removeClass('has-error');
}

$(function () {
	$(':input').on('keypress', function () {
		$(this).nextUntil(':not(.error-message)').remove();
		$(this).removeClass('has-error');
	});
});