class Test {
	constructor() {
		this.number = 3;
	}

	test() {
		function getFirstThis() {
			return this;
		}

		const getSecondThis = () => {
			return this;
		};

		const getThirdThis = getFirstThis.bind(this);

		const $this = this;

		function getFourthThis() {
			return $this;
		}

		// undefined
		console.log(getFirstThis());

		// All return "this" context, containing the number property
		console.log(this);
		console.log(getSecondThis());
		console.log(getThirdThis());
		console.log(getFourthThis());
	}
}

new Test().test();