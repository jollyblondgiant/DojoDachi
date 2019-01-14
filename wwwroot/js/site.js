// Write your Javascript code.
$(()=>{
    console.log("SUCCESS")
    $("#feed").click(()=>{
        $.ajax({
            type: "GET",
            url: "feed",
            
        })
        .done((res)=>{
            if(res.dead)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You Killed Him!")
                
            }
            if(res.win)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You win!")
            }
            else
            {
                $("#status").text("Yum!")
                $("#fullness").html(res.fullness)
                $("#happiness").html(res.happiness)
                $("#energy").html(res.energy)
                $("#meals").html(res.meals)
            }
            
        })
    })
    $("#play").click(()=>{
        $.ajax({
            type: "GET",
            url: "play",
            
        })
        .done((res)=>{
            if(res.dead)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You Killed Him!")
            }
            if(res.win)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You win!")
            }
            else
            {
                $("#status").text("Yay! You plated with your Dachi!")
                $("#fullness").html(res.fullness)
                $("#happiness").html(res.happiness)
                $("#energy").html(res.energy)
                $("#meals").html(res.meals)
            }

        })
    })
    $("#work").click(()=>{
        $.ajax({
            type: "GET",
            url: "work",
            
        })
        .done((res)=>{
            if(res.dead)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You Killed Him!")
            }
            if(res.win)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You win!")
            }
            else
            {
                $("#status").text("Nice Work! Here's Some Food!")
                $("#fullness").html(res.fullness)
                $("#happiness").html(res.happiness)
                $("#energy").html(res.energy)
                $("#meals").html(res.meals)
            }

        })
    })
    $("#sleep").click(()=>{
        $.ajax({
            type: "GET",
            url: "sleep",
            
        })
        .done((res)=>{
            if(res.dead)
            {
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
                $("#status").text("You Killed Him!")
            }
            if(res.win)
            {
                $("#status").text("You win!")
                $("#Navbar").html('<a href =""><button id="restart">Restart</button></a>')
            }
            else
            {
                $("#status").text("ZZZZZ! Energy restored!")
                $("#fullness").html(res.fullness)
                $("#happiness").html(res.happiness)
                $("#energy").html(res.energy)
                $("#meals").html(res.meals)
            }

        })
    })
})