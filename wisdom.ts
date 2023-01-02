
export function generateWisdom(): string {
	return generateSubject() + " " + generateVerb() + " " + generateNoun()
}

function generateSubject(): string {
	const subject = [
		"Duck",
		"He",
		"They",
		"It",
		"She",
		"That",
		"Wisdom",
		"You",
		"Knowledge",
		"Excellence",
		"One",
		"Friend",
		"Guardian",
		"Teacher",
		"Ivy",
		"Aidan", // Sponsored by AidanJSmith
		"Goose", // Sponsored by AidanJSmith
  ];

	return subject[Math.round((Math.random() * subject.length))]
}

function generateVerb(): string {
	const verb = [
		"perceives",
		"understands",
		"values",
		"exemplifies",
		"is",
		"has",
		"delivers",
		"provides",
		"consumes",
		"abolishes",
		"accelerates",
		"achieves",
		"acts with",
		"pictures",
		"confronts",
		"locates",
		"teaches",
		"serves",
		"accesses",
		"incurs",
		"steals",
		"introduces",
		"shows",
		"extracts",
		"forgives",
		"develops",
		"deconstructs",
		"theorizes",
  ];

	return verb[Math.round((Math.random() * verb.length))]
}

function generateNoun(): string {
	const noun = [
		"friendship",
		"kindness",
		"compassion",
		"love",
		"care",
		"entertainment",
		"judgment",
		"jurisdiction",
		"beauty",
		"play",
		"art",
		"understanding",
		"knowledge",
		"theory",
		"power",
		"development",
		"strategy",
		"professionalism",
		"speed",
		"tribulations",
		"potato",
		"communication",
		"warning",
		"income",
		"attention",
		"assistance",
		"perception",
		"imagination",
		"wrath",
		"cats",
		"catgirl",
		"catboy", // Sponsored by AidanJSmith
  ];

	return noun[Math.round((Math.random() * noun.length))]
}
