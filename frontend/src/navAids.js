const NavAidTypeDescriptions = {
  0: "Unspecified Aid to Navigation",
  1: "Reference point",
  2: "RACON (radar transponder marking a navigation hazard",
  3: "Fixed structure off shore, such as oil ",
  4: "Spare, Reserved for future use",
  5: "Light, without sectors",
  6: "Light, with sectors",
  7: "Leading Light Front",
  8: "Leading Light Rear",
  9: "Beacon, Cardinal N",
  10: "Beacon, Cardinal E",
  11: "Beacon, Cardinal S",
  12: "Beacon, Cardinal W",
  13: "Beacon, Port hand",
  14: "Beacon, Starboard hand",
  15: "Beacon, Preferred Channel port hand",
  16: "Beacon, Preferred Channel starboard hand",
  17: "Beacon, Isolated danger",
  18: "Beacon, Safe water",
  19: "Beacon, Special mark",
  20: "Cardinal Mark N",
  21: "Cardinal Mark E",
  22: "Cardinal Mark S",
  23: "Cardinal Mark W",
  24: "Port hand Mark",
  25: "Starboard hand Mark",
  26: "Preferred Channel Port hand",
  27: "Preferred Channel Starboard hand",
  28: "Isolated danger",
  29: "Safe Water",
  30: "Special Mark",
  31: "Light Vessel / LANBY",
};

function getNavAidTypeDescription(navAidType) {
  return NavAidTypeDescriptions[navAidType];
}

export { getNavAidTypeDescription };
