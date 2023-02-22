const basicRules = {
  required: v => !!v || "Required.",
  minLength4: v => v.length >= 4 || "Min 4 characters.",
  minLength8: v => v.length >= 8 || "Min 4 characters.",
  upperRequired: v => /.*[A-Z]/.test(v) || "One or more upper later requred.",
  numberType: v => Number.isInteger(v) || "Value must be number.",
  isFloat: v => v.length === parseFloat(v).length || "Value must be number.",
  lessThanZero: v => v >= 0 || "Value can't be a negative number.",
  greaterThanZero: v => v > 0 || "Value must be greater than zero."
};

const rules = {
  basicRules: basicRules,
  loginRule: [basicRules.required, basicRules.minLength4],
  passwordRule: [basicRules.minLength8, basicRules.upperRequired],
  numberRule: [
    basicRules.required,
    basicRules.numberType,
    basicRules.lessThanZero
  ],
  mineralAndVitaminRule: [basicRules.isFloat, basicRules.lessThanZero],
  macroRule: [basicRules.lessThanZero, basicRules.numberType]
};
export default rules;
