export const COLORS: string[] = [
  "black",  // 0
  "brown",  // 1
  "red",    // 2
  "orange", // 3
  "yellow", // 4
  "green",  // 5
  "blue",   // 6
  "violet", // 7
  "grey",   // 8
  "white"   // 9
];
export function decodedResistorValue([color1, color2, multiplier]: string[]): string {
  const first = COLORS.indexOf(color1);
  const second = COLORS.indexOf(color2);
  const multi = COLORS.indexOf(multiplier);
  
  const rawValue = (first * 10 + second) * Math.pow(10, multi);
  
  if(rawValue >= 1000 && rawValue < 1_000_000){
    return `${rawValue / 1000} kiloohms`
  } else if(rawValue >= 100_000 && rawValue < 1_000_000_000){
    return `${rawValue / 1_000_000} megaohms`
  } else if(rawValue >= 1_000_000_000){
    return `${rawValue / 1_000_000_000} gigaohms`
  }
  return `${rawValue} ohms`
  
}