# Average's Auto Broadcast
Support me & this plugin's (along with several others) development on Ko.Fi: [Here!](https://ko-fi.com/averageterraria)

A super simple and lightweight tShock V5 plugin. It outputs a message to all players at a user-defined interval. You can output as many messages as you would like and also set an RGB message color code per broadcast.

### Config Explained
(tshock/AAutoBC.json)

```json
{
  "messages": [
    {
      "Message": "[Broadcast] This is a test broadcast, the owner has yet to set up this plugin!",
      "Color": {
        "R": 255,
        "G": 255,
        "B": 255
      }
    }
  ],
  "bcInterval": 3
}
```

The `messages` field is a list, which includes Message objects. Each message object has a "Message" string, which can be any amount of text you'd like (this will be output as a broadcast), and a "Color" object, with red, green, and blue values (RGB color codes).

The `bcInterval` is the interval at which messages will be sent out to users, in minutes!
