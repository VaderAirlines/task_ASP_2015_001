ninapp.factory('courseFactory', function () {
    return {
        courses: [
            { id: 1,
              title: 'aaa',
              description: 'dit is de eerste cursus',
              minAge: '0',
              maxAge: '99',
              timing: 'elke zaterdag van januari, van 11u00 tot 21u00',
              location: 'sporthal joske en lowieke',
              address: 'een straat ofzo 25, 2235 Hulshout',
              availablePlaces: 13,
              price: 98
            },
            { id: 2,
              title: 'bbb',
              description: 'dit is de eerste cursus',
              minAge: '0',
              maxAge: '99',
              timing: 'elke zaterdag van januari, van 11u00 tot 21u00',
              location: 'sporthal joske en lowieke',
              address: 'een straat ofzo 25, 2235 Hulshout',
              availablePlaces: 13,
              price: 98
            },
        ]
    };

});