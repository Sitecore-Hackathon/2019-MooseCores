![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo") 

*Installing the Module*

To install the current version of the module you will need the following pre-reqs:

1 - Sitecore 9.1 XP installed
2 - xDB enabled

After ensuring you have all the pre-reqs, just go ahead and install the package through Sitecore Installation Wizard.

*Module Purpose*

The purpose of the GDPR module is to facilitate the Content Authors and Web Admins to easily manage collected data, and promptly repond to any request of the data stored by Sitecore for a given user, and to execute the right to be forgotten, as required by General Data Protection Regulation (GDPR). It is also built in a way to re-process the right to be forgotten on data that, eventually, came back to the website after a disaster recovery through a backup, for example.

*Module Sitecore Hackathon Category*

Best enhancement to the Sitecore Admin (XP) UI for Content Editors & Marketers

*How does the end user use the Module*

The module extends the Experience Profile to allow users to, from inside Sitecore, easily download all the data from a giver user and execute the right to be forgotten.

*Scenario 1*: Download all the data from a specific user

- Once the web admins receive the request to send over all the data collected by the website on a giver user, they can head to the Experience Profile from the Launch Pad

[url=https://postimg.cc/TyN3MQCv][img]https://i.postimg.cc/TyN3MQCv/Experience-Profile.png[/img][/url]

- They will then search for the contact of the user that is requesting GDPR actions

[url=https://postimg.cc/wRLqNzH9][img]https://i.postimg.cc/wRLqNzH9/Experience-Profile-2.png[/img][/url]

- Once they search for the contact and go to the detail page of the contact, a new Tab will show, called GDPR

[url=https://postimg.cc/mz0ZhDvd][img]https://i.postimg.cc/mz0ZhDvd/Experience-Profile-3.png[/img][/url]

- Clicking on the Tab will open some information regaring the user, and relevant to GDPR context

[url=https://postimg.cc/mz0ZhDvd][img]https://i.postimg.cc/mz0ZhDvd/Experience-Profile-3.png[/img][/url]

- On the same page will have a button to request the data from that specific contact. After request the data, a download will start with all the interactions and facets stored by Sitecore to that specific Contact in the JSon format

[url=https://postimg.cc/TLyYRm4L][img]https://i.postimg.cc/TLyYRm4L/Experience-Profile-4.png[/img][/url]

	
* Youtube Video *
https://www.youtube.com/watch?v=X8DeKyBBHF4

*What problem was solved*

The problem this module aims to solve is the usage of Sitecore APIs to allow Content Authors to promptly repond to GDPR requests

*How did you solve it*

We solved this problem by extending the Experience Profile UI to, seamlessly, give more options and information to the Content Authors at the Contact context, without compromising on the Content Authors Experience.

*What is the end result*

The End result is a flexible solution that is easily extensible to add more and more features as APIs arrive and new GDPR requirements are created.
Content Authors will not depend on developers to extract information and, eventually, recover from a disaster or execute the right to be forgotten.
