export function isPangram(sentence:string):boolean {
  const lower = sentence.toLowerCase();

  for (let i = 97; i <= 122; i++) { 
    const char = String.fromCharCode(i);
    if (!lower.includes(char)) {
      return false; 
    }
  }

  return true; 
}
