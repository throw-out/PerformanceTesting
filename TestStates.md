|  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
|  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| static void Payload();       | 1000       | 0.0ms       | 5.9ms       | 5.9ms       | `null`       | `null`       | `null`       |
| static void Payload();       | 10000       | 0.0ms       | 19.5ms       | 30.3ms       | `null`       | `null`       | `null`       |
| static void Payload();       | 100000       | 0.0ms       | 229.2ms       | 296.6ms       | `null`       | `null`       | `null`       |
| void Payload();       | 1000       | 1.0ms       | 3.9ms       | `fail`       | `null`       | `null`       | `null`       |
| void Payload();       | 10000       | 0.0ms       | 20.5ms       | `fail`       | `null`       | `null`       | `null`       |
| void Payload();       | 100000       | 1.0ms       | 195.2ms       | `fail`       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 1000       | 0.0ms       | 4.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 10000       | 0.0ms       | 24.4ms       | 27.4ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 100000       | 1.0ms       | 245.1ms       | 305.8ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 40.1ms       | 34.2ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 325.3ms       | 353.0ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 1.0ms       | 4.9ms       | 6.8ms       | 1501500       | 1003000       | 1003000       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 33.6ms       | 35.2ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 355.4ms       | 372.3ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |