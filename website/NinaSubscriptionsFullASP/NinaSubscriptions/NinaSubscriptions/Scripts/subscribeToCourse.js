// VALIDATION ----------------------------------------------------------------------------------------------------
$(function () {
	$(".component-wrapper #txtDateOfBirth").mask("99/99/9999", { placeholder: "mm/dd/yyyy" });
});

function validateForm(wrapperClass) {
	var max50chars = "dit veld mag niet meer dan 50 karakters bevatten";
	var max10chars = "dit veld mag niet meer dan 10 karakters bevatten";
	var mustComplete = "gelieve dit veld in te vullen";
	var giveDate = "gelieve een datum in te vullen (dd/mm/yyyy)";

	var fields = [
		{
			id: 'txtName',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: { required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtFirstName',
			checks: [{ required: true }, { maxLength: 50 }],
			messages: { required: mustComplete, maxLength: max50chars }
		},
		{
			id: 'txtDateOfBirth',
			checks: [{ required: true }, { maxLength: 10 }, { validDate: true }],
			messages: { required: mustComplete, maxLength: max10chars, validDate: giveDate }
		}
	];

	var retval = validateFields(wrapperClass, fields);

	return retval;
};

function conditionsAccepted() {
	console.log($('#chkConditions').is(':checked'));
	return $('#chkConditions').is(':checked');
}


// DOCUMENT READY ------------------------------------------------------------------------------------------------
(function ($) {

	$(function () {
		/* ACCORDION ELEMENTS ------------------------------------------------------ */
		// cache elements
		var $accordionButtons = $('.button-accordion');

		// initialize accordion elements
		$accordionButtons.children('.accordion-icon').text('+');
		$accordionButtons.next().hide();

		// only open first element/stored element on page load
		var accordionElementIndex = typeof (Storage) == "undefined" ? 0 : localStorage.getItem('Nina_accElIdx');

		if ($accordionButtons.length > 0) {
			$buttonToOpen = $($accordionButtons[accordionElementIndex]);
			openAccordionElement($buttonToOpen);
		};

		// UI handler: toggle open/close state
		$accordionButtons.click(function () {
			if ($(this).next().css('display') === 'block') { return; };
			openAccordionElementExclusively($accordionButtons, $(this));
		});
	});

	// helper: open accordion element
	function openAccordionElement($element) {
		$element.children('.accordion-icon').text('-');
		$element.next().show(500);
	};

	// helper: open accordion element exclusively
	function openAccordionElementExclusively($range, $elementToOpen) {
		openAccordionElement($elementToOpen);

		var elementToOpenIndex = 0;
		var rangeIndex = -1;
		$range.each(function () {
			rangeIndex++;
			$this = $(this);

			if (!$this.is($elementToOpen)) {
				$this.children('.accordion-icon').text('+');
				$this.next().slideUp(500);
			} else {
				elementToOpenIndex = rangeIndex;
			};
		});

		if (typeof (Storage) !== "undefined") {
			localStorage.setItem('Nina_accElIdx', elementToOpenIndex);
		};
	};

})(jQuery);