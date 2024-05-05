; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [137 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [274 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 48
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 136
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 57
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 107
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 64
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 81
	i64 435118502366263740, ; 6: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 82
	i64 545109961164950392, ; 7: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 7
	i64 750875890346172408, ; 8: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 128
	i64 799765834175365804, ; 9: System.ComponentModel.dll => 0xb1956c9f18442ac => 100
	i64 849051935479314978, ; 10: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 10
	i64 872800313462103108, ; 11: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 69
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 86
	i64 1121665720830085036, ; 13: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 18
	i64 1369545283391376210, ; 14: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 77
	i64 1476839205573959279, ; 15: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 113
	i64 1486715745332614827, ; 16: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 54
	i64 1513467482682125403, ; 17: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 135
	i64 1537168428375924959, ; 18: System.Threading.Thread.dll => 0x15551e8a954ae0df => 128
	i64 1556147632182429976, ; 19: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 16
	i64 1624659445732251991, ; 20: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 62
	i64 1628611045998245443, ; 21: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 74
	i64 1735388228521408345, ; 22: System.Net.Mail.dll => 0x181556663c69b759 => 112
	i64 1743969030606105336, ; 23: System.Memory.dll => 0x1833d297e88f2af8 => 109
	i64 1767386781656293639, ; 24: System.Private.Uri.dll => 0x188704e9f5582107 => 117
	i64 1795316252682057001, ; 25: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 61
	i64 1835311033149317475, ; 26: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 27: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 81
	i64 1881198190668717030, ; 28: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1894191570947481469, ; 29: Shared.dll => 0x1a498532aadd1f7d => 91
	i64 1897575647115118287, ; 30: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 82
	i64 1920760634179481754, ; 31: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 55
	i64 1930726298510463061, ; 32: CommunityToolkit.Mvvm.dll => 0x1acb5156cd389055 => 37
	i64 1959996714666907089, ; 33: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 28
	i64 1981742497975770890, ; 34: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 73
	i64 1983698669889758782, ; 35: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 2
	i64 2019660174692588140, ; 36: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 20
	i64 2262844636196693701, ; 37: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 69
	i64 2287834202362508563, ; 38: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 93
	i64 2302323944321350744, ; 39: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 24
	i64 2329709569556905518, ; 40: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 72
	i64 2335503487726329082, ; 41: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 125
	i64 2470498323731680442, ; 42: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 65
	i64 2497223385847772520, ; 43: System.Runtime => 0x22a7eb7046413568 => 122
	i64 2547086958574651984, ; 44: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 60
	i64 2602673633151553063, ; 45: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2612152650457191105, ; 46: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 52
	i64 2656907746661064104, ; 47: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 40
	i64 2662981627730767622, ; 48: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2789714023057451704, ; 49: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 50
	i64 2895129759130297543, ; 50: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 51: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 86
	i64 3289520064315143713, ; 52: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 71
	i64 3311221304742556517, ; 53: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 115
	i64 3325875462027654285, ; 54: System.Runtime.Numerics => 0x2e27e21c8958b48d => 121
	i64 3344514922410554693, ; 55: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 89
	i64 3402534845034375023, ; 56: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 59
	i64 3429672777697402584, ; 57: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 57
	i64 3494946837667399002, ; 58: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 38
	i64 3522470458906976663, ; 59: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 83
	i64 3551103847008531295, ; 60: System.Private.CoreLib.dll => 0x31480e226177735f => 133
	i64 3567343442040498961, ; 61: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 62: System.Runtime.dll => 0x319037675df7e556 => 122
	i64 3638003163729360188, ; 63: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 39
	i64 3647754201059316852, ; 64: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 131
	i64 3655542548057982301, ; 65: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 38
	i64 3727469159507183293, ; 66: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 80
	i64 3869221888984012293, ; 67: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 45
	i64 3890352374528606784, ; 68: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 55
	i64 3933965368022646939, ; 69: System.Net.Requests => 0x369840a8bfadc09b => 114
	i64 3966267475168208030, ; 70: System.Memory => 0x370b03412596249e => 109
	i64 4073500526318903918, ; 71: System.Private.Xml.dll => 0x3887fb25779ae26e => 118
	i64 4073631083018132676, ; 72: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 53
	i64 4120493066591692148, ; 73: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 74: System.ComponentModel => 0x39a7562737acb67e => 100
	i64 4168469861834746866, ; 75: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 123
	i64 4187479170553454871, ; 76: System.Linq.Expressions => 0x3a1cea1e912fa117 => 107
	i64 4205801962323029395, ; 77: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 99
	i64 4356591372459378815, ; 78: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 30
	i64 4477672992252076438, ; 79: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 130
	i64 4657212095206026001, ; 80: Microsoft.Extensions.Http.dll => 0x40a1bdb9c2686b11 => 44
	i64 4679594760078841447, ; 81: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 0
	i64 4743821336939966868, ; 82: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 97
	i64 4794310189461587505, ; 83: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 60
	i64 4795410492532947900, ; 84: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 83
	i64 4853321196694829351, ; 85: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 120
	i64 5017136507397440499, ; 86: Client => 0x45a07312511183f3 => 92
	i64 5290786973231294105, ; 87: System.Runtime.Loader => 0x496ca6b869b72699 => 120
	i64 5471532531798518949, ; 88: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5522859530602327440, ; 89: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 90: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 105
	i64 5573260873512690141, ; 91: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 124
	i64 5692067934154308417, ; 92: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 85
	i64 5979151488806146654, ; 93: System.Formats.Asn1 => 0x52fa3699a489d25e => 104
	i64 6010974535988770325, ; 94: Microsoft.Extensions.Diagnostics.dll => 0x536b457e33877615 => 42
	i64 6068057819846744445, ; 95: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 23
	i64 6200764641006662125, ; 96: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6222399776351216807, ; 97: System.Text.Json.dll => 0x565a67a0ffe264a7 => 126
	i64 6357457916754632952, ; 98: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6401687960814735282, ; 99: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 72
	i64 6478287442656530074, ; 100: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6548213210057960872, ; 101: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 68
	i64 6560151584539558821, ; 102: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 47
	i64 6743165466166707109, ; 103: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6777482997383978746, ; 104: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 22
	i64 6786606130239981554, ; 105: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 103
	i64 6894844156784520562, ; 106: System.Numerics.Vectors => 0x5faf683aead1ad72 => 115
	i64 7220009545223068405, ; 107: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 26
	i64 7270811800166795866, ; 108: System.Linq => 0x64e71ccf51a90a5a => 108
	i64 7377312882064240630, ; 109: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 99
	i64 7489048572193775167, ; 110: System.ObjectModel => 0x67ee71ff6b419e3f => 116
	i64 7496222613193209122, ; 111: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 59
	i64 7654504624184590948, ; 112: System.Net.Http => 0x6a3a4366801b8264 => 111
	i64 7694700312542370399, ; 113: System.Net.Mail => 0x6ac9112a7e2cda5f => 112
	i64 7708790323521193081, ; 114: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 17
	i64 7714652370974252055, ; 115: System.Private.CoreLib => 0x6b0ff375198b9c17 => 133
	i64 7735352534559001595, ; 116: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 88
	i64 7836164640616011524, ; 117: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 62
	i64 7919757340696389605, ; 118: Microsoft.Extensions.Diagnostics.Abstractions => 0x6de8a157378027e5 => 43
	i64 8064050204834738623, ; 119: System.Collections.dll => 0x6fe942efa61731bf => 96
	i64 8083354569033831015, ; 120: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 71
	i64 8085230611270010360, ; 121: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 110
	i64 8087206902342787202, ; 122: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 102
	i64 8167236081217502503, ; 123: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 134
	i64 8185542183669246576, ; 124: System.Collections => 0x7198e33f4794aa70 => 96
	i64 8246048515196606205, ; 125: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 58
	i64 8368701292315763008, ; 126: System.Security.Cryptography => 0x7423997c6fd56140 => 124
	i64 8381604729589167482, ; 127: Shared => 0x745171180ae5757a => 91
	i64 8400357532724379117, ; 128: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 79
	i64 8518412311883997971, ; 129: System.Collections.Immutable => 0x76377add7c28e313 => 94
	i64 8563666267364444763, ; 130: System.Private.Uri => 0x76d841191140ca5b => 117
	i64 8599632406834268464, ; 131: CommunityToolkit.Maui => 0x7758081c784b4930 => 35
	i64 8614108721271900878, ; 132: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 21
	i64 8626175481042262068, ; 133: Java.Interop => 0x77b654e585b55834 => 134
	i64 8639588376636138208, ; 134: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 78
	i64 8677882282824630478, ; 135: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 136: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 102
	i64 8816904670177563593, ; 137: Microsoft.Extensions.Diagnostics => 0x7a5bf015646a93c9 => 42
	i64 9045785047181495996, ; 138: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9312692141327339315, ; 139: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 85
	i64 9324707631942237306, ; 140: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 61
	i64 9427266486299436557, ; 141: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 51
	i64 9575902398040817096, ; 142: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 87
	i64 9659729154652888475, ; 143: System.Text.RegularExpressions => 0x860e407c9991dd9b => 127
	i64 9678050649315576968, ; 144: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 65
	i64 9702891218465930390, ; 145: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 95
	i64 9808709177481450983, ; 146: Mono.Android.dll => 0x881f890734e555e7 => 136
	i64 9956195530459977388, ; 147: Microsoft.Maui => 0x8a2b8315b36616ac => 56
	i64 9991543690424095600, ; 148: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 6
	i64 10038780035334861115, ; 149: System.Net.Http.dll => 0x8b50e941206af13b => 111
	i64 10051358222726253779, ; 150: System.Private.Xml => 0x8b7d990c97ccccd3 => 118
	i64 10092835686693276772, ; 151: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 54
	i64 10143853363526200146, ; 152: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10229024438826829339, ; 153: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 68
	i64 10406448008575299332, ; 154: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 89
	i64 10430153318873392755, ; 155: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 66
	i64 10506226065143327199, ; 156: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10785150219063592792, ; 157: System.Net.Primitives => 0x95ac8cfb68830758 => 113
	i64 10880838204485145808, ; 158: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 35
	i64 11002576679268595294, ; 159: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 46
	i64 11009005086950030778, ; 160: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 56
	i64 11103970607964515343, ; 161: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11162124722117608902, ; 162: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 84
	i64 11220793807500858938, ; 163: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 164: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 47
	i64 11340910727871153756, ; 165: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 67
	i64 11485890710487134646, ; 166: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 119
	i64 11517440453979132662, ; 167: Microsoft.IdentityModel.Abstractions.dll => 0x9fd62b122523d2f6 => 49
	i64 11518296021396496455, ; 168: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 169: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 84
	i64 11530571088791430846, ; 170: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 45
	i64 11705530742807338875, ; 171: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 9
	i64 12145679461940342714, ; 172: System.Text.Json => 0xa88e1f1ebcb62fba => 126
	i64 12162774915823022194, ; 173: Client.dll => 0xa8cadb5844a9b072 => 92
	i64 12269460666702402136, ; 174: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 94
	i64 12341818387765915815, ; 175: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 36
	i64 12439275739440478309, ; 176: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 50
	i64 12451044538927396471, ; 177: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 70
	i64 12466513435562512481, ; 178: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 75
	i64 12475113361194491050, ; 179: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12517810545449516888, ; 180: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 103
	i64 12538491095302438457, ; 181: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 63
	i64 12550732019250633519, ; 182: System.IO.Compression => 0xae2d28465e8e1b2f => 106
	i64 12681088699309157496, ; 183: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 14
	i64 12700543734426720211, ; 184: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 64
	i64 12823819093633476069, ; 185: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 27
	i64 12843321153144804894, ; 186: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 48
	i64 12864607843777505167, ; 187: Client.Infrastructure.dll => 0xb28844ac9f0fe78f => 90
	i64 13221551921002590604, ; 188: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 1
	i64 13222659110913276082, ; 189: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 15
	i64 13343850469010654401, ; 190: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 135
	i64 13381594904270902445, ; 191: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13465488254036897740, ; 192: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 88
	i64 13467053111158216594, ; 193: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 29
	i64 13540124433173649601, ; 194: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13545416393490209236, ; 195: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 13
	i64 13572454107664307259, ; 196: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 80
	i64 13717397318615465333, ; 197: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 98
	i64 13755568601956062840, ; 198: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 8
	i64 13814445057219246765, ; 199: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 11
	i64 13881769479078963060, ; 200: System.Console.dll => 0xc0a5f3cade5c6774 => 101
	i64 13959074834287824816, ; 201: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 70
	i64 14100563506285742564, ; 202: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 3
	i64 14124974489674258913, ; 203: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 63
	i64 14125464355221830302, ; 204: System.Threading.dll => 0xc407bafdbc707a9e => 129
	i64 14461014870687870182, ; 205: System.Net.Requests.dll => 0xc8afd8683afdece6 => 114
	i64 14464374589798375073, ; 206: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14522721392235705434, ; 207: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 5
	i64 14551742072151931844, ; 208: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 125
	i64 14556034074661724008, ; 209: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 36
	i64 14669215534098758659, ; 210: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 40
	i64 14690985099581930927, ; 211: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 130
	i64 14705122255218365489, ; 212: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14744092281598614090, ; 213: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 214: System.Security.Claims => 0xcdd816ef5d6e873a => 123
	i64 14852515768018889994, ; 215: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 67
	i64 14892012299694389861, ; 216: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 33
	i64 14904040806490515477, ; 217: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14954917835170835695, ; 218: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 41
	i64 14987728460634540364, ; 219: System.IO.Compression.dll => 0xcfff1ba06622494c => 106
	i64 15024878362326791334, ; 220: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 110
	i64 15051741671811457419, ; 221: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0xd0e2874d8f44218b => 43
	i64 15076659072870671916, ; 222: System.ObjectModel.dll => 0xd13b0d8c1620662c => 116
	i64 15111608613780139878, ; 223: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 224: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 105
	i64 15133485256822086103, ; 225: System.Linq.dll => 0xd204f0a9127dd9d7 => 108
	i64 15138356091203993725, ; 226: Microsoft.IdentityModel.Abstractions => 0xd2163ea89395c07d => 49
	i64 15227001540531775957, ; 227: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 39
	i64 15370334346939861994, ; 228: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 66
	i64 15391712275433856905, ; 229: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 41
	i64 15527772828719725935, ; 230: System.Console => 0xd77dbb1e38cd3d6f => 101
	i64 15536481058354060254, ; 231: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15582737692548360875, ; 232: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 74
	i64 15609085926864131306, ; 233: System.dll => 0xd89e9cf3334914ea => 132
	i64 15661133872274321916, ; 234: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 131
	i64 15664356999916475676, ; 235: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 4
	i64 15743187114543869802, ; 236: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 12
	i64 15783653065526199428, ; 237: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15928521404965645318, ; 238: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 53
	i64 16154507427712707110, ; 239: System => 0xe03056ea4e39aa26 => 132
	i64 16288847719894691167, ; 240: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 241: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 46
	i64 16558262036769511634, ; 242: Microsoft.Extensions.Http => 0xe5cac397cf7b98d2 => 44
	i64 16648892297579399389, ; 243: CommunityToolkit.Mvvm => 0xe70cbf55c4f508dd => 37
	i64 16649148416072044166, ; 244: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 58
	i64 16677317093839702854, ; 245: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 79
	i64 16890310621557459193, ; 246: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 127
	i64 16942731696432749159, ; 247: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16998075588627545693, ; 248: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 77
	i64 17008137082415910100, ; 249: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 95
	i64 17031351772568316411, ; 250: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 76
	i64 17062143951396181894, ; 251: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 98
	i64 17089008752050867324, ; 252: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 32
	i64 17137864900836977098, ; 253: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 52
	i64 17187273293601214786, ; 254: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 97
	i64 17317683239488641116, ; 255: Client.Infrastructure => 0xf054c5273e74d85c => 90
	i64 17342750010158924305, ; 256: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17360349973592121190, ; 257: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 87
	i64 17438153253682247751, ; 258: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 25
	i64 17514990004910432069, ; 259: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17623389608345532001, ; 260: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17702523067201099846, ; 261: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 31
	i64 17704177640604968747, ; 262: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 75
	i64 17710060891934109755, ; 263: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 73
	i64 17712670374920797664, ; 264: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 119
	i64 17777860260071588075, ; 265: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 121
	i64 17790600151040787804, ; 266: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 51
	i64 18025913125965088385, ; 267: System.Threading => 0xfa28e87b91334681 => 129
	i64 18099568558057551825, ; 268: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 19
	i64 18121036031235206392, ; 269: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 76
	i64 18146411883821974900, ; 270: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 104
	i64 18245806341561545090, ; 271: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 93
	i64 18305135509493619199, ; 272: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 78
	i64 18324163916253801303 ; 273: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [274 x i32] [
	i32 48, ; 0
	i32 136, ; 1
	i32 57, ; 2
	i32 107, ; 3
	i32 64, ; 4
	i32 81, ; 5
	i32 82, ; 6
	i32 7, ; 7
	i32 128, ; 8
	i32 100, ; 9
	i32 10, ; 10
	i32 69, ; 11
	i32 86, ; 12
	i32 18, ; 13
	i32 77, ; 14
	i32 113, ; 15
	i32 54, ; 16
	i32 135, ; 17
	i32 128, ; 18
	i32 16, ; 19
	i32 62, ; 20
	i32 74, ; 21
	i32 112, ; 22
	i32 109, ; 23
	i32 117, ; 24
	i32 61, ; 25
	i32 6, ; 26
	i32 81, ; 27
	i32 28, ; 28
	i32 91, ; 29
	i32 82, ; 30
	i32 55, ; 31
	i32 37, ; 32
	i32 28, ; 33
	i32 73, ; 34
	i32 2, ; 35
	i32 20, ; 36
	i32 69, ; 37
	i32 93, ; 38
	i32 24, ; 39
	i32 72, ; 40
	i32 125, ; 41
	i32 65, ; 42
	i32 122, ; 43
	i32 60, ; 44
	i32 27, ; 45
	i32 52, ; 46
	i32 40, ; 47
	i32 2, ; 48
	i32 50, ; 49
	i32 7, ; 50
	i32 86, ; 51
	i32 71, ; 52
	i32 115, ; 53
	i32 121, ; 54
	i32 89, ; 55
	i32 59, ; 56
	i32 57, ; 57
	i32 38, ; 58
	i32 83, ; 59
	i32 133, ; 60
	i32 22, ; 61
	i32 122, ; 62
	i32 39, ; 63
	i32 131, ; 64
	i32 38, ; 65
	i32 80, ; 66
	i32 45, ; 67
	i32 55, ; 68
	i32 114, ; 69
	i32 109, ; 70
	i32 118, ; 71
	i32 53, ; 72
	i32 33, ; 73
	i32 100, ; 74
	i32 123, ; 75
	i32 107, ; 76
	i32 99, ; 77
	i32 30, ; 78
	i32 130, ; 79
	i32 44, ; 80
	i32 0, ; 81
	i32 97, ; 82
	i32 60, ; 83
	i32 83, ; 84
	i32 120, ; 85
	i32 92, ; 86
	i32 120, ; 87
	i32 26, ; 88
	i32 29, ; 89
	i32 105, ; 90
	i32 124, ; 91
	i32 85, ; 92
	i32 104, ; 93
	i32 42, ; 94
	i32 23, ; 95
	i32 23, ; 96
	i32 126, ; 97
	i32 34, ; 98
	i32 72, ; 99
	i32 11, ; 100
	i32 68, ; 101
	i32 47, ; 102
	i32 19, ; 103
	i32 22, ; 104
	i32 103, ; 105
	i32 115, ; 106
	i32 26, ; 107
	i32 108, ; 108
	i32 99, ; 109
	i32 116, ; 110
	i32 59, ; 111
	i32 111, ; 112
	i32 112, ; 113
	i32 17, ; 114
	i32 133, ; 115
	i32 88, ; 116
	i32 62, ; 117
	i32 43, ; 118
	i32 96, ; 119
	i32 71, ; 120
	i32 110, ; 121
	i32 102, ; 122
	i32 134, ; 123
	i32 96, ; 124
	i32 58, ; 125
	i32 124, ; 126
	i32 91, ; 127
	i32 79, ; 128
	i32 94, ; 129
	i32 117, ; 130
	i32 35, ; 131
	i32 21, ; 132
	i32 134, ; 133
	i32 78, ; 134
	i32 21, ; 135
	i32 102, ; 136
	i32 42, ; 137
	i32 31, ; 138
	i32 85, ; 139
	i32 61, ; 140
	i32 51, ; 141
	i32 87, ; 142
	i32 127, ; 143
	i32 65, ; 144
	i32 95, ; 145
	i32 136, ; 146
	i32 56, ; 147
	i32 6, ; 148
	i32 111, ; 149
	i32 118, ; 150
	i32 54, ; 151
	i32 3, ; 152
	i32 68, ; 153
	i32 89, ; 154
	i32 66, ; 155
	i32 1, ; 156
	i32 113, ; 157
	i32 35, ; 158
	i32 46, ; 159
	i32 56, ; 160
	i32 12, ; 161
	i32 84, ; 162
	i32 15, ; 163
	i32 47, ; 164
	i32 67, ; 165
	i32 119, ; 166
	i32 49, ; 167
	i32 13, ; 168
	i32 84, ; 169
	i32 45, ; 170
	i32 9, ; 171
	i32 126, ; 172
	i32 92, ; 173
	i32 94, ; 174
	i32 36, ; 175
	i32 50, ; 176
	i32 70, ; 177
	i32 75, ; 178
	i32 34, ; 179
	i32 103, ; 180
	i32 63, ; 181
	i32 106, ; 182
	i32 14, ; 183
	i32 64, ; 184
	i32 27, ; 185
	i32 48, ; 186
	i32 90, ; 187
	i32 1, ; 188
	i32 15, ; 189
	i32 135, ; 190
	i32 9, ; 191
	i32 88, ; 192
	i32 29, ; 193
	i32 30, ; 194
	i32 13, ; 195
	i32 80, ; 196
	i32 98, ; 197
	i32 8, ; 198
	i32 11, ; 199
	i32 101, ; 200
	i32 70, ; 201
	i32 3, ; 202
	i32 63, ; 203
	i32 129, ; 204
	i32 114, ; 205
	i32 24, ; 206
	i32 5, ; 207
	i32 125, ; 208
	i32 36, ; 209
	i32 40, ; 210
	i32 130, ; 211
	i32 16, ; 212
	i32 32, ; 213
	i32 123, ; 214
	i32 67, ; 215
	i32 33, ; 216
	i32 0, ; 217
	i32 41, ; 218
	i32 106, ; 219
	i32 110, ; 220
	i32 43, ; 221
	i32 116, ; 222
	i32 17, ; 223
	i32 105, ; 224
	i32 108, ; 225
	i32 49, ; 226
	i32 39, ; 227
	i32 66, ; 228
	i32 41, ; 229
	i32 101, ; 230
	i32 4, ; 231
	i32 74, ; 232
	i32 132, ; 233
	i32 131, ; 234
	i32 4, ; 235
	i32 12, ; 236
	i32 5, ; 237
	i32 53, ; 238
	i32 132, ; 239
	i32 18, ; 240
	i32 46, ; 241
	i32 44, ; 242
	i32 37, ; 243
	i32 58, ; 244
	i32 79, ; 245
	i32 127, ; 246
	i32 25, ; 247
	i32 77, ; 248
	i32 95, ; 249
	i32 76, ; 250
	i32 98, ; 251
	i32 32, ; 252
	i32 52, ; 253
	i32 97, ; 254
	i32 90, ; 255
	i32 10, ; 256
	i32 87, ; 257
	i32 25, ; 258
	i32 8, ; 259
	i32 20, ; 260
	i32 31, ; 261
	i32 75, ; 262
	i32 73, ; 263
	i32 119, ; 264
	i32 121, ; 265
	i32 51, ; 266
	i32 129, ; 267
	i32 19, ; 268
	i32 76, ; 269
	i32 104, ; 270
	i32 93, ; 271
	i32 78, ; 272
	i32 14 ; 273
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}