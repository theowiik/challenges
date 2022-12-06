const fs = require('fs');

const daySix = (data, length) => {
  let i = 0;

  while (i < data.length) {
    const subPart = data.substring(i, i + length).split('');

    const hasDupe = subPart.some(
      (c) => subPart.indexOf(c) !== subPart.lastIndexOf(c)
    );

    if (!hasDupe) {
      return i + length;
    }

    i++;
  }
};

const line = fs.readFileSync('data').toString();

console.log(`Part 1: ${daySix(line, 4)}`);
console.log(`Part 2: ${daySix(line, 14)}`);
