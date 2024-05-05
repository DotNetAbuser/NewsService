; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [137 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [274 x i32] [
	i32 42639949, ; 0: System.Threading.Thread => 0x28aa24d => 128
	i32 67008169, ; 1: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 2: Microsoft.Maui.Graphics.dll => 0x44bb714 => 58
	i32 98325684, ; 3: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 43
	i32 117431740, ; 4: System.Runtime.InteropServices => 0x6ffddbc => 119
	i32 159306688, ; 5: System.ComponentModel.Annotations => 0x97ed3c0 => 97
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 64
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 83
	i32 195452805, ; 8: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 9: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 10: System.ComponentModel => 0xc38ff48 => 100
	i32 221958352, ; 11: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 42
	i32 279614728, ; 12: Client => 0x10aa9508 => 92
	i32 280992041, ; 13: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 291275502, ; 14: Microsoft.Extensions.Http.dll => 0x115c82ee => 44
	i32 317674968, ; 15: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 16: Xamarin.AndroidX.Activity.dll => 0x13031348 => 60
	i32 336156722, ; 17: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 18: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 71
	i32 356389973, ; 19: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 379916513, ; 20: System.Threading.Thread.dll => 0x16a510e1 => 128
	i32 385762202, ; 21: System.Memory.dll => 0x16fe439a => 109
	i32 395744057, ; 22: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 23: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 24: System.Collections => 0x1a61054f => 96
	i32 450948140, ; 25: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 70
	i32 456227837, ; 26: System.Web.HttpUtility.dll => 0x1b317bfd => 130
	i32 469710990, ; 27: System.dll => 0x1bff388e => 132
	i32 485463106, ; 28: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 49
	i32 498788369, ; 29: System.ObjectModel => 0x1dbae811 => 116
	i32 500358224, ; 30: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 31: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 32: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 48
	i32 539058512, ; 33: Microsoft.Extensions.Logging => 0x20216150 => 45
	i32 592146354, ; 34: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 597488923, ; 35: CommunityToolkit.Maui => 0x239cf51b => 35
	i32 627609679, ; 36: Xamarin.AndroidX.CustomView => 0x2568904f => 68
	i32 627931235, ; 37: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 645360334, ; 38: Shared => 0x26776ace => 91
	i32 662205335, ; 39: System.Text.Encodings.Web.dll => 0x27787397 => 125
	i32 672442732, ; 40: System.Collections.Concurrent => 0x2814a96c => 93
	i32 688181140, ; 41: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 706645707, ; 42: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 43: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 44: System.Runtime.Loader.dll => 0x2b15ed29 => 120
	i32 759454413, ; 45: System.Net.Requests => 0x2d445acd => 114
	i32 775507847, ; 46: System.IO.Compression => 0x2e394f87 => 106
	i32 777317022, ; 47: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 48: Microsoft.Extensions.Options => 0x2f0980eb => 47
	i32 823281589, ; 49: System.Private.Uri.dll => 0x311247b5 => 117
	i32 830298997, ; 50: System.IO.Compression.Brotli => 0x317d5b75 => 105
	i32 878954865, ; 51: System.Net.Http.Json => 0x3463c971 => 110
	i32 904024072, ; 52: System.ComponentModel.Primitives.dll => 0x35e25008 => 98
	i32 926902833, ; 53: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 966729478, ; 54: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 87
	i32 967690846, ; 55: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 71
	i32 992768348, ; 56: System.Collections.dll => 0x3b2c715c => 96
	i32 1012816738, ; 57: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 81
	i32 1028951442, ; 58: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 41
	i32 1029334545, ; 59: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 60: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 61
	i32 1044663988, ; 61: System.Linq.Expressions.dll => 0x3e444eb4 => 107
	i32 1048992957, ; 62: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 43
	i32 1052210849, ; 63: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1082857460, ; 64: System.ComponentModel.TypeConverter => 0x408b17f4 => 99
	i32 1084122840, ; 65: Xamarin.Kotlin.StdLib => 0x409e66d8 => 88
	i32 1098259244, ; 66: System => 0x41761b2c => 132
	i32 1118262833, ; 67: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 68: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 69: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 78
	i32 1203215381, ; 70: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1214827643, ; 71: CommunityToolkit.Mvvm => 0x4868cc7b => 37
	i32 1234928153, ; 72: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1260983243, ; 73: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 74: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 69
	i32 1324164729, ; 75: System.Linq => 0x4eed2679 => 108
	i32 1373134921, ; 76: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 77: Xamarin.AndroidX.SavedState => 0x52114ed3 => 81
	i32 1406073936, ; 78: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 65
	i32 1430672901, ; 79: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1435222561, ; 80: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 87
	i32 1452070440, ; 81: System.Formats.Asn1.dll => 0x568cd628 => 104
	i32 1460893475, ; 82: System.IdentityModel.Tokens.Jwt => 0x57137723 => 59
	i32 1461004990, ; 83: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 84: System.Collections.Immutable.dll => 0x5718a9ef => 94
	i32 1462112819, ; 85: System.IO.Compression.dll => 0x57261233 => 106
	i32 1469204771, ; 86: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 62
	i32 1470490898, ; 87: Microsoft.Extensions.Primitives => 0x57a5e912 => 48
	i32 1479771757, ; 88: System.Collections.Immutable => 0x5833866d => 94
	i32 1480492111, ; 89: System.IO.Compression.Brotli.dll => 0x583e844f => 105
	i32 1493001747, ; 90: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1498168481, ; 91: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 50
	i32 1505131794, ; 92: Microsoft.Extensions.Http => 0x59b67d12 => 44
	i32 1514721132, ; 93: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 94: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 127
	i32 1551623176, ; 95: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1622152042, ; 96: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 97: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 85
	i32 1634654947, ; 98: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 36
	i32 1636350590, ; 99: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 67
	i32 1639515021, ; 100: System.Net.Http.dll => 0x61b9038d => 111
	i32 1639986890, ; 101: System.Text.RegularExpressions => 0x61c036ca => 127
	i32 1657153582, ; 102: System.Runtime => 0x62c6282e => 122
	i32 1658251792, ; 103: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 86
	i32 1677501392, ; 104: System.Net.Primitives.dll => 0x63fca3d0 => 113
	i32 1679769178, ; 105: System.Security.Cryptography => 0x641f3e5a => 124
	i32 1729485958, ; 106: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 63
	i32 1736233607, ; 107: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 108: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 109: System.Diagnostics.TraceSource.dll => 0x69239124 => 103
	i32 1766324549, ; 110: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 83
	i32 1770582343, ; 111: Microsoft.Extensions.Logging.dll => 0x6988f147 => 45
	i32 1780572499, ; 112: Mono.Android.Runtime.dll => 0x6a216153 => 135
	i32 1782862114, ; 113: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 114: Xamarin.AndroidX.Fragment => 0x6a96652d => 70
	i32 1793755602, ; 115: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 116: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813058853, ; 117: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 88
	i32 1813201214, ; 118: Xamarin.Google.Android.Material => 0x6c13413e => 86
	i32 1818569960, ; 119: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 79
	i32 1828688058, ; 120: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 46
	i32 1842015223, ; 121: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 122: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 123: System.Linq.Expressions => 0x6ec71a65 => 107
	i32 1875935024, ; 124: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1910275211, ; 125: System.Collections.NonGeneric.dll => 0x71dc7c8b => 95
	i32 1961813231, ; 126: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 82
	i32 1968388702, ; 127: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 38
	i32 1986222447, ; 128: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 52
	i32 2003115576, ; 129: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 130: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2025202353, ; 131: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2045470958, ; 132: System.Private.Xml => 0x79eb68ee => 118
	i32 2055257422, ; 133: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 72
	i32 2066184531, ; 134: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 135: System.Diagnostics.TraceSource => 0x7b6f419e => 103
	i32 2079903147, ; 136: System.Runtime.dll => 0x7bf8cdab => 122
	i32 2088561200, ; 137: Client.Infrastructure => 0x7c7cea30 => 90
	i32 2090596640, ; 138: System.Numerics.Vectors => 0x7c9bf920 => 115
	i32 2127167465, ; 139: System.Console => 0x7ec9ffe9 => 101
	i32 2159891885, ; 140: Microsoft.Maui => 0x80bd55ad => 56
	i32 2169148018, ; 141: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 142: Microsoft.Extensions.Options.dll => 0x820d22b3 => 47
	i32 2192057212, ; 143: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 46
	i32 2193016926, ; 144: System.ObjectModel.dll => 0x82b6c85e => 116
	i32 2201107256, ; 145: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 89
	i32 2201231467, ; 146: System.Net.Http => 0x8334206b => 111
	i32 2207618523, ; 147: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 148: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 39
	i32 2270573516, ; 149: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 150: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 80
	i32 2298471582, ; 151: System.Net.Mail => 0x88ffe49e => 112
	i32 2303942373, ; 152: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 153: System.Private.CoreLib.dll => 0x896b7878 => 133
	i32 2353062107, ; 154: System.Net.Primitives => 0x8c40e0db => 113
	i32 2368005991, ; 155: System.Xml.ReaderWriter.dll => 0x8d24e767 => 131
	i32 2369706906, ; 156: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 51
	i32 2371007202, ; 157: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 38
	i32 2395872292, ; 158: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 159: System.Web.HttpUtility => 0x8f24faee => 130
	i32 2427813419, ; 160: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 161: System.Console.dll => 0x912896e5 => 101
	i32 2475788418, ; 162: Java.Interop.dll => 0x93918882 => 134
	i32 2480646305, ; 163: Microsoft.Maui.Controls => 0x93dba8a1 => 54
	i32 2534521373, ; 164: Shared.dll => 0x9711ba1d => 91
	i32 2550873716, ; 165: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2570120770, ; 166: System.Text.Encodings.Web => 0x9930ee42 => 125
	i32 2593496499, ; 167: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 168: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 89
	i32 2617129537, ; 169: System.Private.Xml.dll => 0x9bfe3a41 => 118
	i32 2620871830, ; 170: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 67
	i32 2626831493, ; 171: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2640290731, ; 172: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 51
	i32 2663698177, ; 173: System.Runtime.Loader => 0x9ec4cf01 => 120
	i32 2717744543, ; 174: System.Security.Claims => 0xa1fd7d9f => 123
	i32 2724373263, ; 175: System.Runtime.Numerics.dll => 0xa262a30f => 121
	i32 2732626843, ; 176: Xamarin.AndroidX.Activity => 0xa2e0939b => 60
	i32 2737747696, ; 177: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 62
	i32 2752995522, ; 178: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 179: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 55
	i32 2764765095, ; 180: Microsoft.Maui.dll => 0xa4caf7a7 => 56
	i32 2778768386, ; 181: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 84
	i32 2785988530, ; 182: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 183: Microsoft.Maui.Graphics => 0xa7008e0b => 58
	i32 2806116107, ; 184: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 185: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 65
	i32 2831556043, ; 186: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 187: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 84
	i32 2861189240, ; 188: Microsoft.Maui.Essentials => 0xaa8a4878 => 57
	i32 2868488919, ; 189: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 36
	i32 2909740682, ; 190: System.Private.CoreLib => 0xad6f1e8a => 133
	i32 2916838712, ; 191: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 85
	i32 2919462931, ; 192: System.Numerics.Vectors.dll => 0xae037813 => 115
	i32 2959614098, ; 193: System.ComponentModel.dll => 0xb0682092 => 100
	i32 2978675010, ; 194: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 69
	i32 2987532451, ; 195: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 82
	i32 3020703001, ; 196: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 42
	i32 3038032645, ; 197: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 198: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 76
	i32 3059408633, ; 199: Mono.Android.Runtime => 0xb65adef9 => 135
	i32 3059793426, ; 200: System.ComponentModel.Primitives => 0xb660be12 => 98
	i32 3077302341, ; 201: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3082788452, ; 202: Client.Infrastructure.dll => 0xb7bf9e64 => 90
	i32 3084678329, ; 203: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 52
	i32 3099732863, ; 204: System.Security.Claims.dll => 0xb8c22b7f => 123
	i32 3103600923, ; 205: System.Formats.Asn1 => 0xb8fd311b => 104
	i32 3178803400, ; 206: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 77
	i32 3220365878, ; 207: System.Threading => 0xbff2e236 => 129
	i32 3258312781, ; 208: Xamarin.AndroidX.CardView => 0xc235e84d => 63
	i32 3280506390, ; 209: System.ComponentModel.Annotations.dll => 0xc3888e16 => 97
	i32 3305363605, ; 210: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3312457198, ; 211: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 50
	i32 3316684772, ; 212: System.Net.Requests.dll => 0xc5b097e4 => 114
	i32 3317135071, ; 213: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 68
	i32 3346324047, ; 214: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 78
	i32 3357674450, ; 215: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 216: System.Text.Json => 0xc82afec1 => 126
	i32 3362522851, ; 217: Xamarin.AndroidX.Core => 0xc86c06e3 => 66
	i32 3366347497, ; 218: Java.Interop => 0xc8a662e9 => 134
	i32 3374999561, ; 219: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 80
	i32 3381016424, ; 220: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 221: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 40
	i32 3452344032, ; 222: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 53
	i32 3463511458, ; 223: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 224: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 99
	i32 3476120550, ; 225: Mono.Android => 0xcf3163e6 => 136
	i32 3479583265, ; 226: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 227: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 228: System.Text.Json.dll => 0xcfbaacae => 126
	i32 3572198165, ; 229: Client.dll => 0xd4eb6b15 => 92
	i32 3580758918, ; 230: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 231: System.Linq.dll => 0xd715a361 => 108
	i32 3641597786, ; 232: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 72
	i32 3643446276, ; 233: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 234: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 77
	i32 3657292374, ; 235: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 39
	i32 3672681054, ; 236: Mono.Android.dll => 0xdae8aa5e => 136
	i32 3697841164, ; 237: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3700591436, ; 238: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 49
	i32 3724971120, ; 239: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 76
	i32 3737834244, ; 240: System.Net.Http.Json.dll => 0xdecad304 => 110
	i32 3748608112, ; 241: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 102
	i32 3786282454, ; 242: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 64
	i32 3792276235, ; 243: System.Collections.NonGeneric => 0xe2098b0b => 95
	i32 3800979733, ; 244: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 53
	i32 3817368567, ; 245: CommunityToolkit.Maui.dll => 0xe3886bf7 => 35
	i32 3823082795, ; 246: System.Security.Cryptography.dll => 0xe3df9d2b => 124
	i32 3841636137, ; 247: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 41
	i32 3844307129, ; 248: System.Net.Mail.dll => 0xe52378b9 => 112
	i32 3849253459, ; 249: System.Runtime.InteropServices.dll => 0xe56ef253 => 119
	i32 3889960447, ; 250: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 251: System.Collections.Concurrent.dll => 0xe839deed => 93
	i32 3896760992, ; 252: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 66
	i32 3928044579, ; 253: System.Xml.ReaderWriter => 0xea213423 => 131
	i32 3931092270, ; 254: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 79
	i32 3955647286, ; 255: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 61
	i32 3980434154, ; 256: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 257: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4025784931, ; 258: System.Memory => 0xeff49a63 => 109
	i32 4046471985, ; 259: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 55
	i32 4073602200, ; 260: System.Threading.dll => 0xf2ce3c98 => 129
	i32 4094352644, ; 261: Microsoft.Maui.Essentials.dll => 0xf40add04 => 57
	i32 4100113165, ; 262: System.Private.Uri => 0xf462c30d => 117
	i32 4102112229, ; 263: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4125707920, ; 264: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 265: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 40
	i32 4150914736, ; 266: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4182413190, ; 267: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4213026141, ; 268: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 102
	i32 4263231520, ; 269: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 59
	i32 4271975918, ; 270: Microsoft.Maui.Controls.dll => 0xfea12dee => 54
	i32 4274623895, ; 271: CommunityToolkit.Mvvm.dll => 0xfec99597 => 37
	i32 4274976490, ; 272: System.Runtime.Numerics => 0xfecef6ea => 121
	i32 4292120959 ; 273: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [274 x i32] [
	i32 128, ; 0
	i32 33, ; 1
	i32 58, ; 2
	i32 43, ; 3
	i32 119, ; 4
	i32 97, ; 5
	i32 64, ; 6
	i32 83, ; 7
	i32 30, ; 8
	i32 31, ; 9
	i32 100, ; 10
	i32 42, ; 11
	i32 92, ; 12
	i32 2, ; 13
	i32 44, ; 14
	i32 30, ; 15
	i32 60, ; 16
	i32 15, ; 17
	i32 71, ; 18
	i32 14, ; 19
	i32 128, ; 20
	i32 109, ; 21
	i32 34, ; 22
	i32 26, ; 23
	i32 96, ; 24
	i32 70, ; 25
	i32 130, ; 26
	i32 132, ; 27
	i32 49, ; 28
	i32 116, ; 29
	i32 13, ; 30
	i32 7, ; 31
	i32 48, ; 32
	i32 45, ; 33
	i32 21, ; 34
	i32 35, ; 35
	i32 68, ; 36
	i32 19, ; 37
	i32 91, ; 38
	i32 125, ; 39
	i32 93, ; 40
	i32 1, ; 41
	i32 16, ; 42
	i32 4, ; 43
	i32 120, ; 44
	i32 114, ; 45
	i32 106, ; 46
	i32 25, ; 47
	i32 47, ; 48
	i32 117, ; 49
	i32 105, ; 50
	i32 110, ; 51
	i32 98, ; 52
	i32 28, ; 53
	i32 87, ; 54
	i32 71, ; 55
	i32 96, ; 56
	i32 81, ; 57
	i32 41, ; 58
	i32 3, ; 59
	i32 61, ; 60
	i32 107, ; 61
	i32 43, ; 62
	i32 73, ; 63
	i32 99, ; 64
	i32 88, ; 65
	i32 132, ; 66
	i32 16, ; 67
	i32 22, ; 68
	i32 78, ; 69
	i32 20, ; 70
	i32 37, ; 71
	i32 18, ; 72
	i32 2, ; 73
	i32 69, ; 74
	i32 108, ; 75
	i32 32, ; 76
	i32 81, ; 77
	i32 65, ; 78
	i32 0, ; 79
	i32 87, ; 80
	i32 104, ; 81
	i32 59, ; 82
	i32 6, ; 83
	i32 94, ; 84
	i32 106, ; 85
	i32 62, ; 86
	i32 48, ; 87
	i32 94, ; 88
	i32 105, ; 89
	i32 10, ; 90
	i32 50, ; 91
	i32 44, ; 92
	i32 5, ; 93
	i32 127, ; 94
	i32 25, ; 95
	i32 75, ; 96
	i32 85, ; 97
	i32 36, ; 98
	i32 67, ; 99
	i32 111, ; 100
	i32 127, ; 101
	i32 122, ; 102
	i32 86, ; 103
	i32 113, ; 104
	i32 124, ; 105
	i32 63, ; 106
	i32 23, ; 107
	i32 1, ; 108
	i32 103, ; 109
	i32 83, ; 110
	i32 45, ; 111
	i32 135, ; 112
	i32 17, ; 113
	i32 70, ; 114
	i32 9, ; 115
	i32 75, ; 116
	i32 88, ; 117
	i32 86, ; 118
	i32 79, ; 119
	i32 46, ; 120
	i32 29, ; 121
	i32 26, ; 122
	i32 107, ; 123
	i32 8, ; 124
	i32 95, ; 125
	i32 82, ; 126
	i32 38, ; 127
	i32 52, ; 128
	i32 5, ; 129
	i32 73, ; 130
	i32 0, ; 131
	i32 118, ; 132
	i32 72, ; 133
	i32 4, ; 134
	i32 103, ; 135
	i32 122, ; 136
	i32 90, ; 137
	i32 115, ; 138
	i32 101, ; 139
	i32 56, ; 140
	i32 12, ; 141
	i32 47, ; 142
	i32 46, ; 143
	i32 116, ; 144
	i32 89, ; 145
	i32 111, ; 146
	i32 14, ; 147
	i32 39, ; 148
	i32 8, ; 149
	i32 80, ; 150
	i32 112, ; 151
	i32 18, ; 152
	i32 133, ; 153
	i32 113, ; 154
	i32 131, ; 155
	i32 51, ; 156
	i32 38, ; 157
	i32 13, ; 158
	i32 130, ; 159
	i32 10, ; 160
	i32 101, ; 161
	i32 134, ; 162
	i32 54, ; 163
	i32 91, ; 164
	i32 11, ; 165
	i32 125, ; 166
	i32 20, ; 167
	i32 89, ; 168
	i32 118, ; 169
	i32 67, ; 170
	i32 15, ; 171
	i32 51, ; 172
	i32 120, ; 173
	i32 123, ; 174
	i32 121, ; 175
	i32 60, ; 176
	i32 62, ; 177
	i32 21, ; 178
	i32 55, ; 179
	i32 56, ; 180
	i32 84, ; 181
	i32 27, ; 182
	i32 58, ; 183
	i32 6, ; 184
	i32 65, ; 185
	i32 19, ; 186
	i32 84, ; 187
	i32 57, ; 188
	i32 36, ; 189
	i32 133, ; 190
	i32 85, ; 191
	i32 115, ; 192
	i32 100, ; 193
	i32 69, ; 194
	i32 82, ; 195
	i32 42, ; 196
	i32 34, ; 197
	i32 76, ; 198
	i32 135, ; 199
	i32 98, ; 200
	i32 12, ; 201
	i32 90, ; 202
	i32 52, ; 203
	i32 123, ; 204
	i32 104, ; 205
	i32 77, ; 206
	i32 129, ; 207
	i32 63, ; 208
	i32 97, ; 209
	i32 7, ; 210
	i32 50, ; 211
	i32 114, ; 212
	i32 68, ; 213
	i32 78, ; 214
	i32 24, ; 215
	i32 126, ; 216
	i32 66, ; 217
	i32 134, ; 218
	i32 80, ; 219
	i32 3, ; 220
	i32 40, ; 221
	i32 53, ; 222
	i32 11, ; 223
	i32 99, ; 224
	i32 136, ; 225
	i32 24, ; 226
	i32 23, ; 227
	i32 126, ; 228
	i32 92, ; 229
	i32 31, ; 230
	i32 108, ; 231
	i32 72, ; 232
	i32 28, ; 233
	i32 77, ; 234
	i32 39, ; 235
	i32 136, ; 236
	i32 33, ; 237
	i32 49, ; 238
	i32 76, ; 239
	i32 110, ; 240
	i32 102, ; 241
	i32 64, ; 242
	i32 95, ; 243
	i32 53, ; 244
	i32 35, ; 245
	i32 124, ; 246
	i32 41, ; 247
	i32 112, ; 248
	i32 119, ; 249
	i32 32, ; 250
	i32 93, ; 251
	i32 66, ; 252
	i32 131, ; 253
	i32 79, ; 254
	i32 61, ; 255
	i32 27, ; 256
	i32 9, ; 257
	i32 109, ; 258
	i32 55, ; 259
	i32 129, ; 260
	i32 57, ; 261
	i32 117, ; 262
	i32 22, ; 263
	i32 17, ; 264
	i32 40, ; 265
	i32 29, ; 266
	i32 74, ; 267
	i32 102, ; 268
	i32 59, ; 269
	i32 54, ; 270
	i32 37, ; 271
	i32 121, ; 272
	i32 74 ; 273
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
