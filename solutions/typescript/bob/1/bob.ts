export function hey(sentence: string): string {
  
  const trimmed:string = sentence.trim();
  const isQuestion:boolean = trimmed.endsWith("?");
  const isYelling:boolean = trimmed.toUpperCase() === trimmed && /[A-Z]/.test(trimmed)
  const isSilence = trimmed === "";
  
  if(isSilence) 
  {
    return "Fine. Be that way!"
  }

  if(isQuestion) 
  {
    if(isYelling) 
    {
      return "Calm down, I know what I'm doing!"
    } 
    return "Sure.";
  }
  
  if(isYelling) 
  {
    return "Whoa, chill out!";
  }

  return "Whatever.";
}
  


/*
If the sentence is empty                                                  say Fine. Be that way!"
If the sentence DOES contain ? and without CAPITAL                        say Sure.
If the sentence DOES contain ? and with CAPITAL                           say "Calm down, I know what I'm doing!"
If the sentence DOES NOT contain ? and with CAPITAL                       say "Whoa, chill out!"
Anything else                                                             say "Whatever"


*/
