function ConvertIntoUppercase(input) {

  let result = input.toUpperCase()
    .split(/[\W]+/)
    .filter(w => w.length > 0)
    .join(", ");

  console.log(result);
}

