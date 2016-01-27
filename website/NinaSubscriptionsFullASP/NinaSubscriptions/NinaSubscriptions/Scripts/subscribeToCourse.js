(function ($) {

	$(function () {
		/* ACCORDION ELEMENTS ------------------------------------------------------ */
		// cache elements
		var $accordionButtons = $('.button-accordion');

		// only open first element on page load
		$accordionButtons.children('.accordion-icon').text('+');
		$accordionButtons.next().hide();

		if ($accordionButtons.length > 0) {
			$firstButton = $($accordionButtons[0]);
			openAccordionElement($firstButton);
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

		$range.each(function() {
			$this = $(this);
			
			if (!$this.is($elementToOpen)) {
				$this.children('.accordion-icon').text('+');
				$this.next().slideUp(500);
			};
		});
	};
		
})(jQuery);