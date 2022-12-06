const fs = require('fs');
const line = fs.readFileSync('data').toString();

const daySix = (data, length) => {
  for (let i = 0; i < data.length; i++) {
    const subPart = data.substring(i, i + length).split('');

    const hasDupe = subPart.some(
      (c) => subPart.indexOf(c) !== subPart.lastIndexOf(c)
    );

    if (!hasDupe) return i + length;
  }
};

console.log(`Part 1: ${daySix(line, 4)}`);
console.log(`Part 2: ${daySix(line, 14)}`);
