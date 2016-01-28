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