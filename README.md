# SEO Project

The project runs off local IIS, I based it off a visual studio react project template so you will need node, npm and react to execute the web component.

I haven't fleshed out the Bing search classes, but they give an example of how I would extend the project to provide other search providers.

The redis caching key isn't ideal, but I think for the size of the project it should work okay. I am relying on the TTL to ensure that the project doesn't hit the google search api more than once per hour. I use Memurai on my local machine as the windows implementation of Redis.

If this was going to be a project that needed to be supported in the long term I would add in validation, error handling, logging, more comments, swagger documentation for the endpoints and get someone else to provide decent styling into the project. This is a minimum viable product that I would iterate on, when tasked with improvements or new features I would include time to refactor the existing code and add these things in to my estimates.
