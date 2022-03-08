# PerformanceTesting
 Unity游戏引擎, C#原生丶puerts脚本丶xLua脚本性能测试横向对比
 
 
|  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
|  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| static void Payload();       | 1000       | 0.0ms       | 6.8ms       | 5.9ms       | <null>       | <null>       | <null>       |
| static void Payload();       | 10000       | 0.0ms       | 16.6ms       | 26.4ms       | <null>       | <null>       | <null>       |
| static void Payload();       | 100000       | 1.0ms       | 189.6ms       | 259.5ms       | <null>       | <null>       | <null>       |
| void Payload();       | 1000       | 0.5ms       | 4.9ms       | Fail       | <null>       | <null>       | <null>       |
| void Payload();       | 10000       | 0.0ms       | 20.6ms       | Fail       | <null>       | <null>       | <null>       |
| void Payload();       | 100000       | 1.0ms       | 232.4ms       | Fail       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 1000       | 1.0ms       | 5.9ms       | 3.9ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 10000       | 0.0ms       | 22.5ms       | 27.4ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 100000       | 1.5ms       | 234.0ms       | 291.8ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 3.9ms       | 4.9ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 30.9ms       | 36.2ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 297.0ms       | 358.5ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 5.9ms       | 5.9ms       | 1501500       | 1003000       | 1003000       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 36.2ms       | 40.1ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 357.6ms       | 372.3ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |
