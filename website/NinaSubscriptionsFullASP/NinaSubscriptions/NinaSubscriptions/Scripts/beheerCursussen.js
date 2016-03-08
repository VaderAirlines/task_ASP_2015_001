(function ($) {

	$(function () {
		// HIDE NECESSARY FIELDS
		$('.edit').hide();
		$('.no-edit-course').hide();
		$('.save-course').hide();
		$('.originalValue').hide();
		$('.newValue').hide();
		$('.saving').hide();
		$('.callbackMessage').hide();

		// FIELD MASKS
		$(".component-wrapper .date").mask("99/99/9999", { placeholder: "mm/dd/yyyy" });
		$(".component-wrapper .hour").mask("99:99", { placeholder: "hh:hh" });

		// DROPDOWN INIT/HANDLERS
		var $dropdowns = $('.component-wrapper').find('select');
		$dropdowns.each(function () {
			var $this = $(this);
			var originalValue = $this.prev('.originalValue').text();
			$this.val(originalValue);
			$this.attr('data-originalValue', originalValue);
		});

		// BUTTON HANDLERS
		$('.edit-course').click(function () {
			var $wrapper = $(this).parent().parent().parent();
			var $labels = $wrapper.find('.no-edit');
			var $textfields = $wrapper.find('.edit');
			var $saveButton = $wrapper.find('.save-course');

			$labels.each(function () {
				$(this).hide();
			});

			$textfields.each(function () {
				$(this).show();
			});

			$saveButton.attr('data-enabled', '1');

			$(this).hide();
			$wrapper.find('.no-edit-course').show();
			$wrapper.find('.save-course').show();
		});

		$('.no-edit-course').click(function () {
			var $wrapper = $(this).parent().parent().parent();
			var $labels = $wrapper.find('.no-edit');
			var $editfields = $wrapper.find('.edit');
			var $saveButton = $wrapper.find('.save-course');

			$editfields.each(function () {
				var $textfields = $(this).find('input');
				var $selects = $(this).find('select');

				$textfields.each(function () {
					$(this).val($(this).attr('data-originalValue'));
				});

				$selects.each(function () {
					$(this).val($(this).attr('data-originalValue'));
				});
			});


			$labels.each(function () {
				$(this).show();
			});

			$editfields.each(function () {
				$(this).hide();
			});

			$saveButton.attr('data-enabled', '0');

			$(this).hide();
			$wrapper.find('.save-course').hide();
			$wrapper.find('.edit-course').show();
		});

		$('.save-course').click(function () {
			var $wrapper = $(this).parent().parent().parent();
			var courseID = $wrapper.find('.course-id').val();
			var description = $wrapper.find('.description').val();
			var courseType = $wrapper.find('.courseType').val();
			var startDate = $wrapper.find('.startDate').val();
			var endDate = $wrapper.find('.endDate').val();
			var locationID = $wrapper.find('.location').val();
			var maxSubscriptions = $wrapper.find('.maxSubscriptions').val();
			var price = $wrapper.find('.price').val();
			var startHour = $wrapper.find('.startHour').val();
			var endHour = $wrapper.find('.endHour').val();
			var name = $wrapper.find('.name').val();

			saveChangesToCourse($wrapper, courseID, description, courseType, startDate, endDate, locationID, maxSubscriptions, price, startHour, endHour, name);
		});

	});

	function saveChangesToCourse($wrapper, courseID, description, courseType, startDate, endDate, locationID, maxSubscriptions, price, startHour, endHour, name) {
		var $ready = $wrapper.find('.ready');
		var $saving = $wrapper.find('.saving');
		var $message = $wrapper.find('.callbackMessage');
		var $goBack = $wrapper.find('.no-edit-course');

		$ready.hide();
		$saving.show();
		$message.hide();

		var req = $.ajax({
			type: "POST",
			contentType: "application/json; charset=utf-8",
			url: "../../Webservices/courseService.asmx/saveChangesToCourse",
			data: JSON.stringify({
				courseID: courseID, description: description, courseTypeID: courseType,
				startDate: startDate, endDate: endDate, locationID: locationID,
				maxSubscriptions: maxSubscriptions, price: price, startHour: startHour,
				endHour: endHour, name: name
			}),
			dataType: "json"
		});

		req.done(function (data) {
			if (data.d == "success") {
				updateItemData($wrapper);
				showMessage($message, 'success', $ready, $saving, $goBack);
			} else {
				showMessage($message, 'failed', $ready, $saving, $goBack, data.d);
			}
		});

		req.fail(function (xhr, status, error) {
			console.log('course saving failed: ' + xhr.ResponseText);
			showMessage($message, 'failed', $ready, $saving);
		});
	};

	function showMessage($element, which, $ready, $saving, $goBack, customErrorMessage) {
		if (which == 'success') {
			$element.text('De cursus is opgeslagen.').css('background-color', 'green');
		} else {
			var errorMessage = typeof customErrorMessage == 'undefined' ? 'De cursus kon niet worden opgeslagen.' : customErrorMessage;
			$element.text(customErrorMessage).css('background-color', 'red');
		};

		$element.show();
		setTimeout(function () {
			$element.hide(500);
			$ready.show();
			$saving.hide();
			if (which == 'success') $goBack.trigger('click');
		}, 1500);
	};

	function updateItemData($wrapper) {
		var $textfields = $wrapper.find('input');
		var $selects = $wrapper.find('select');

		$textfields.each(function () {
			var newValue = $(this).val();
			var id = $(this).attr('id');
			if (typeof id == "undefined") return false;
			
			var firstClass = getFirstClass(id);
			var $label = $(this).prev('.' + firstClass + '-lbl');

			$label.css('background-color', 'red');
		});

		$selects.each(function () {
			var newValue = $(this).val();
			var id = $(this).attr('id');
			var firstClass = getFirstClass(id);
			var $label = $(this).prev('.' + firstClass + '-lbl');

			$label.css('background-color', 'red');
		});
	}

	function getFirstClass(id) {
		var classList = document.getElementById(id).className.split(/\s+/);
		if (classList.length > 0) return classList[0];
		return '';
	}

})(jQuery);

// VALIDATION
function validateForm(wrapperClass) {
	var max50chars = "dit veld mag niet meer dan 50 karakters bevatten";
	var mustComplete = "gelieve dit veld in te vullen";
	var giveEmail = "gelieve een geldig emailadres in te vullen";
	var validDate = "gelieve een geldige datum in te vullen";
	var validHour = "gelieve een geldig uur in te vullen (hh:mm)";
	var numeric = "gelieve een positief geheel getal in te vullen";

	var fields = [
		{
			id: 'txtNewName',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: { required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtNewDescription',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: { required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtNewStartDate',
			checks: [{ required: true }, { validDate: true }],
			messages: { required: mustComplete, validDate: validDate }
		},
		{
			id: 'txtNewEndDateInclusive',
			checks: [{ required: true }, { validDate: true }],
			messages: { required: mustComplete, validDate: validDate }
		},
		{
			id: 'txtNewStartHour',
			checks: [{ required: true }, { hour: true }],
			messages: { required: mustComplete, hour: validHour }
		},
		{
			id: 'txtNewEndHour',
			checks: [{ required: true }, { hour: true }],
			messages: { required: mustComplete, hour: validHour }
		},
		{
			id: 'txtNewMaxSubscriptions',
			checks: [{ required: true }, { numeric: true }],
			messages: { required: mustComplete, numeric: numeric }
		},
		{
			id: 'txtNewPrice',
			checks: [{ required: true }, { numeric: true }],
			messages: { required: mustComplete, numeric: numeric }
		}
	];

	var retval = validateFields(wrapperClass, fields);

	return retval;
};