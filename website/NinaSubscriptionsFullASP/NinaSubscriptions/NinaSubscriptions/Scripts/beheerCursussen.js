(function ($) {

	$(function () {
		/* HIDE NECESSARY FIELDS*/
		$('.edit').hide();
		$('.no-edit-course').hide();
		$('.originalValue').hide();
		$('.newValue').hide();
		$('.saving').hide();
		$('.callbackMessage').hide();

		// DROPDOWN INIT/HANDLERS
		var $dropdowns = $('.component-wrapper').find('select');
		$dropdowns.each(function () {
			var $this = $(this);
			var originalValue = $this.prev('.originalValue').text();
			$this.val(originalValue);
		});

		/* BUTTON HANDLERS */
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
		});

		$('.no-edit-course').click(function () {
			var $wrapper = $(this).parent().parent().parent();
			var $labels = $wrapper.find('.no-edit');
			var $textfields = $wrapper.find('.edit');
			var $saveButton = $wrapper.find('.save-course');

			$labels.each(function () {
				var $this = $(this);
				var $textbox = $this.next().find('input[type=text]');

				$textbox.each(function () {
					$(this).val($(this).attr('data-originalValue'));
				});

				$this.show();
			});

			$textfields.each(function () {
				$(this).hide();
			});

			$saveButton.attr('data-enabled', '0');

			$(this).hide();
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

			saveChangesToCourse($wrapper, courseID, description, courseType, startDate, endDate, locationID, maxSubscriptions, price);
		});

	});

	function saveChangesToCourse($wrapper, courseID, description, courseType, startDate, endDate, locationID, maxSubscriptions, price) {
		var $ready = $wrapper.find('.ready');
		var $saving = $wrapper.find('.saving');
		var $message = $wrapper.find('.callbackMessage');

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
				maxSubscriptions: maxSubscriptions, price: price
			}),
			dataType: "json"
		});

		req.done(function (data) {
			console.log(data.d);
			console.log(data.d === true);
			
			if (data.d == true) {
				showMessage($message, 'success');
			} else {
				showMessage($message, 'failed');
			}
		});

		req.fail(function (xhr, status, error) {
			console.log('course saving failed: ' + xhr.ResponseText);
			showMessage($message, 'failed');
		});
	};

	function showMessage($element, which) {
		if (which == 'success') {
			$element.text('De cursus is opgeslagen.').css('background-color', 'green');
		} else {
			$element.text('De cursus kon niet worden opgeslagen.').css('background-color', 'red');
		};

		$element.show();
		setTimeout(function () {
			$element.hide(500);
			$ready.show();
			$saving.hide();
		}, 1500);
	};

})(jQuery);
