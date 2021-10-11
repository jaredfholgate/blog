import React from 'react'

const AboutMe = () => {
  return (
    <div className="home">
      <div class="container">
        <h4>Welcome to my Blog!</h4>
        <p>I've been working in software engineering since about 2001, although I had a passion for IT since we got our first BBC Micro when was a kid. Following university, I started out at a large Brewery in Leeds in the UK, which has since been closed down (nothing to do with my coding skills!). Since then I've worked in financial services, commercial software and a global Law Firm. I've lived in various places during that time, including the UK, the Cayman Islands and Montreal in Canada.</p>
        <p>I am currently in a managerial role, but I like to get my hands dirty and this Blog is designed to help go beyond my day to day technology stack.</p>
        <p>My passion is DevOps, Continuous Integration and Continuous Delivery. Over the last 10 years, I've worked with Cruise Control, XAML builds in XML, Web Deploy, hand crafted tools, PowerShell and various other tools and techniques to automate the software delivery pipeline. Over the past few years VMWare, Octopus Deploy, VSTS / TFS Build vNext, Desired State Configuration and VSTS / TFS Release Management have been game changing. Even more recently I have been pursuing Containers, Infrastructure as Code (DSC, Puppet and Chef), Azure Service Fabric, Docker Enterprise, Kubernetes and others to tackle the operations side. I also work with Actifio for Database DevOps.</p>
        <p>Automated testing with TDD Unit Tests, Integration / API Tests and CodedUI / Selenium GUI testing are also something I work and consult on a lot. Getting the testing pyramid just right is difficult, especially with legacy (low coverage) code bases. Breaking down monoliths, front end client script frameworks (e.g. AngularJS and TypeScript), micro services, git source control, trunk based branching, feature flagging, package management with NPM and Nuget, event driven architecture, refactoring and managing technical debt are also things I am heavily involved in. Agile development practices, particularly Scrum and Kanban are very important to my way of thinking. Elastic Search, Authentication Providers, Caching, Logging, Application Monitoring, the list goes on... You get the idea, I'm very busy and I enjoy trying to remove bottlenecks and improve the quality, frequency and value of the product flowing into production.</p>
        <p>With so many emerging technologies and practices, it's an exciting time to be involved in Software Engineering, I look forward to seeing what the next few years bring.</p>
        <p>Outside work I enjoy spending time with family, running (when I'm not injured), hiking, diving, reading science fiction and technology books. Oh and writing a blog if I keep it up!...</p>
        <p>I hope you enjoy the articles.</p>
        <p>Jared (September 2017)</p>
        <p><a href="https://twitter.com/jaredfholgate" target="_blank" rel="noreferrer">@jaredfholgate</a></p>
      </div>
    </div>
  );
};

export default AboutMe;
