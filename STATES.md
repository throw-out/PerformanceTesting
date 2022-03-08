| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 1.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 0.0ms       | 17.6ms       | 23.5ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 0.0ms       | 182.7ms       | 235.5ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 20.5ms       | 40.4ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 1.0ms       | 207.1ms       | 349.6ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 1.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 20.5ms       | 26.4ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 0.0ms       | 230.8ms       | 273.6ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 3.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 29.3ms       | 31.3ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 320.5ms       | 333.2ms       | `null`       | `null`       | `null`       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 1000       | 1.0ms       | 5.9ms       | 5.9ms       | 1501500       | 1501500       | 1501500       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 31.3ms       | 36.2ms       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 323.4ms       | 376.7ms       | 1.500022E+10       | 1.500015E+10       | 15000150000       |