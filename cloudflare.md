## The cloudflare incident
In one of their useEffect hooks, a new object was included in the dependency. This caused the hook to loop infinitly becuase to was called continiously becuase the new object cause the it to execute again. 
## How my code prevents a similar loop:
I implemented dependency array discipline: I ensured my useEffect only watches stable variables (like the room filter or data source). I never include a state that I am currently updating inside its own dependency array.
