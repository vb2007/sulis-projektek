/**
 * Converts a unicode string to the rendered emoji
 * @param {string} emoji The emoji to be converted in te format: `U+hex`
 * @returns {string} The converted string
 */
export const formatEmoji = (emoji) => {
    return String.fromCodePoint(parseInt(emoji.replace("U+", ""), 16));
};
