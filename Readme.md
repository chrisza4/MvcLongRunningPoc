# MVC Longrunning

This app demonstrate how performing background task with disposable services might lead to unexpected behaviour.

In Home/Index, it can perform background task of logging as expected because we use non-disposable object (System.Console). In this case, long running task will work just fine.

In Home/Privacy, we use a disposable task performer. The TaskPerformer will be disposed after controller finish. Hence the long running task will be failed.

More detail article [here](https://anduin.aiursoft.com/post/2020/10/14/fire-and-forget-in-aspnet-core-with-dependency-alive?fbclid=IwAR3gS7ITQaEBPrhxj-7C0c3y_xq7b_9shnFM4K4y2JyOw3Oed-gB5vRZ1u4)