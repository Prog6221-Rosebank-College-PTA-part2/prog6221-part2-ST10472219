
using System;

namespace CyberBot_2
{
    public class ChatbotEngine
    {
        private string currentTopic = "";
        private string userName = "";

        // MAIN CHATBOT METHOD
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a message.";
            }

            input = input.ToLower();

            // PASSWORDS
            if (input.Contains("password"))
            {
                currentTopic = "password";

                return
@"PASSWORD SAFETY

• Use strong passwords with uppercase letters, lowercase letters, numbers, and symbols.
• Avoid using easy passwords like 123456.
• Never share passwords with anyone.
• Use different passwords for different accounts.
• Enable two-factor authentication.";
            }

            // PHISHING
            if (input.Contains("phishing"))
            {
                currentTopic = "phishing";

                return
@"PHISHING AWARENESS
• Phishing scams pretend to be trusted companies.
• Never click suspicious links.
• Check email addresses carefully.
• Never enter passwords on unknown websites.
• Delete suspicious emails immediately.";
            }

            // PRIVACY
            if (input.Contains("privacy"))
            {
                currentTopic = "privacy";

                return
@"ONLINE PRIVACY

• Keep personal information private.
• Review social media privacy settings.
• Avoid sharing your location publicly.
• Log out from shared computers.
• Use strong passwords.";
            }

            // SCAMS
            if (input.Contains("scam"))
            {
                currentTopic = "scam";

                return
@"ONLINE SCAMS

• Never send money to strangers online.
• Do not share OTP codes.
• Be careful of fake giveaways.
• Verify information before paying.
• Ignore urgent suspicious messages.";
            }

            // MALWARE
            if (input.Contains("malware"))
            {
                currentTopic = "malware";

                return
@"MALWARE PROTECTION

• Install antivirus software.
• Avoid unsafe downloads.
• Update your computer regularly.
• Scan USB devices before opening files.
• Avoid cracked software.";
            }

            // VIRUS
            if (input.Contains("virus"))
            {
                currentTopic = "virus";

                return
@"COMPUTER VIRUSES

• Viruses damage files and systems.
• Use antivirus protection.
• Avoid suspicious attachments.
• Keep Windows updated.
• Backup important files.";
            }

            // HACKERS
            if (input.Contains("hacker"))
            {
                currentTopic = "hacker";

                return
@"HACKER SAFETY

• Use strong passwords.
• Enable two-factor authentication.
• Avoid suspicious websites.
• Never share login information.
• Keep software updated.";
            }

            // CYBERBULLYING
            if (input.Contains("cyberbullying"))
            {
                currentTopic = "cyberbullying";

                return
@"CYBERBULLYING SAFETY

• Block and report bullies.
• Save evidence.
• Do not respond to harmful messages.
• Speak to trusted adults.
• Protect your privacy online.";
            }

            // SAFE BROWSING
            if (input.Contains("safe browsing"))
            {
                currentTopic = "safe browsing";

                return
@"SAFE BROWSING

• Visit trusted websites only.
• Check for HTTPS websites.
• Avoid suspicious downloads.
• Keep browsers updated.
• Use antivirus protection.";
            }

            // MORE / EXPLAIN
            if (input.Contains("more") || input.Contains("explain"))
            {
                if (currentTopic == "password")
                {
                    return "Strong passwords protect accounts from hackers and cybercriminals.";
                }

                if (currentTopic == "phishing")
                {
                    return "Phishing attacks steal passwords, banking details, and personal information.";
                }

                if (currentTopic == "malware")
                {
                    return "Malware includes viruses, spyware, worms, and ransomware.";
                }
            }

            // DEFAULT RESPONSE
            return "I can help with passwords, phishing, privacy, scams, malware, viruses, hackers, cyberbullying, and safe browsing.";
        }
    }
}
