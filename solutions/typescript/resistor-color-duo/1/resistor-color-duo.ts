export const COLORS = [
      'black',
      'brown',
      'red',
      'orange',
      'yellow',
      'green',
      'blue',
      'violet',
      'grey',
      'white',
]

export function decodedValue(color1:string, color2:string) {
  const indexComboString = String(COLORS.indexOf(color1.toLowerCase())) + String(COLORS.indexOf(color2.toLowerCase()));;
  const indexComboNumber = Number(indexComboString);
  return indexComboNumber;
}


