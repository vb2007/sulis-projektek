/// Basic English singularization for relationship key generation.
String singular(String word) {
  if (word.endsWith('ies')) return '${word.substring(0, word.length - 3)}y';
  if (word.endsWith('ses') ||
      word.endsWith('xes') ||
      word.endsWith('zes') ||
      word.endsWith('ches') ||
      word.endsWith('shes')) {
    return word.substring(0, word.length - 2);
  }
  if (word.endsWith('s') && !word.endsWith('ss')) {
    return word.substring(0, word.length - 1);
  }
  return word;
}
