#include "X86Avx.h"

#include <stdio.h>
#include <inttypes.h>
#include <malloc.h>
#include <immintrin.h>

int8_t demo_int8[32];
int16_t demo_int16[16];
int32_t demo_int32[8];
int64_t demo_int64[4];

void Widen_SByte() {
    __m256i v0, v1;
    //392:                     Vector.Widen(Vectors<sbyte>.Demo, out var low, out var high);
    //00007FFBCD18EF61  mov         rcx, 120BCEB6608h
    //00007FFBCD18EF6B  mov         rcx, qword ptr[rcx]
    //00007FFBCD18EF6E  vmovupd     ymm0, ymmword ptr[rcx + 8]
    //00007FFBCD18EF73  vmovupd     ymmword ptr[rbp - 790h], ymm0
    //00007FFBCD18EF7B  vmovupd     ymm0, ymmword ptr[rbp - 790h]
    //00007FFBCD18EF83  vpermq      ymm0, ymm0, 0D4h
    //00007FFBCD18EF89  vxorps      ymm1, ymm1, ymm1
    //00007FFBCD18EF8D  vpcmpgtb    ymm1, ymm1, ymm0
    //00007FFBCD18EF91  vpunpcklbw  ymm0, ymm0, ymm1
    //00007FFBCD18EF95  vmovupd     ymmword ptr[rbp - 70h], ymm0
    //00007FFBCD18EF9A  vmovupd     ymm0, ymmword ptr[rbp - 790h]
    //00007FFBCD18EFA2  vpermq      ymm0, ymm0, 0E8h
    //00007FFBCD18EFA8  vxorps      ymm1, ymm1, ymm1
    //00007FFBCD18EFAC  vpcmpgtb    ymm1, ymm1, ymm0
    //00007FFBCD18EFB0  vpunpckhbw  ymm0, ymm0, ymm1
    //00007FFBCD18EFB4  vmovupd     ymmword ptr[rbp - 90h], ymm0
    __m256i src = _mm256_load_si256((__m256i*) & demo_int8[0]); // vmovupd     ymm0,ymmword ptr [rbp-790h]
    v0 = _mm256_permute4x64_epi64(src, 0xD4); // vpermq      ymm0, ymm0, 0D4h; 0D4h=0b1101_0100{3,1,1,0} // v0 = {`i64[0]`, i64[1], `i64[1]`, i64[3]}; 带(`)的是重点, 其他的2组会被忽略.
    __m256i zero = _mm256_setzero_si256(); // vxorps      ymm1, ymm1, ymm1
    __m256i mask = _mm256_cmpgt_epi8(zero, v0); // vpcmpgtb    ymm1, ymm1, ymm0 // mask 将存储高半部分的符号位: make = { 0 > i8[i] }
    v0 = _mm256_unpacklo_epi8(v0, mask); // vpunpcklbw  ymm0, ymm0, ymm1 // vpunpcklbw 是128位为一组, 处理低64位的解包. v0.i128[0] = unpack(v0.i64[0], mask) = unpack(src.i64[0], mask), v0.i128[1] = unpack(v0.i64[2], mask) = unpack(src.i64[1], mask)
    v1 = _mm256_permute4x64_epi64(src, 0xE8); // vpermq      ymm0, ymm0, 0E8h; 0E8h=0b1110_1000{3,2,2,0}} // v1 = {i64[0], `i64[2]`, i64[2], `i64[3]`};
    mask = _mm256_cmpgt_epi8(zero, v1); // vpcmpgtb    ymm1, ymm1, ymm0
    v1 = _mm256_unpackhi_epi8(v1, mask); // vpunpckhbw  ymm0, ymm0, ymm1 // vpunpckhbw 是128位为一组, 处理高64位的解包. v0.i128[0] = unpack(v0.i64[1], mask) = unpack(src.i64[2], mask), v0.i128[1] = unpack(v0.i64[3], mask) = unpack(src.i64[3], mask)

    // done.
    printf("Widen_SByte:\t%d\n", src.m256i_i32[0]);
}

void Narrow_Int16() {
    __m256i ymm0, ymm1, ymm2, ymm3;
    //    309:                 WriteLine(tw, indent, "Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative));
    // 00007FFBCB9033B9  mov         rcx,7FFBCB3C6860h  
    // 00007FFBCB9033C3  mov         edx,1  
    // 00007FFBCB9033C8  call        CORINFO_HELP_NEWARR_1_OBJ (07FFC2AF8B090h)  
    // 00007FFBCB9033CD  mov         qword ptr [rbp-0BF8h],rax  
    // 00007FFBCB9033D4  mov         rdx,224EF7B7FA0h  
    // 00007FFBCB9033DE  mov         rdx,qword ptr [rdx]  
    // 00007FFBCB9033E1  vmovupd     ymm0,ymmword ptr [rdx+8]  
    // 00007FFBCB9033E6  mov         rdx,224EF7B7F98h  
    // 00007FFBCB9033F0  mov         rdx,qword ptr [rdx]  
    // 00007FFBCB9033F3  vmovupd     ymm1,ymmword ptr [rdx+8]  
    // 00007FFBCB9033F8  vperm2i128  ymm3,ymm0,ymm1,20h  
    // 00007FFBCB9033FE  vperm2i128  ymm2,ymm0,ymm1,31h  
    // 00007FFBCB903404  vpsllw      ymm3,ymm3,8  
    // 00007FFBCB903409  vpsrlw      ymm3,ymm3,8  
    // 00007FFBCB90340E  vpsllw      ymm2,ymm2,8  
    // 00007FFBCB903413  vpsrlw      ymm2,ymm2,8  
    // 00007FFBCB903418  vpackuswb   ymm0,ymm3,ymm2  
    // 00007FFBCB90341C  vmovupd     ymmword ptr [rbp-0C30h],ymm0  
    ymm0 = _mm256_load_si256((__m256i*) & demo_int16[0]); // ymm0=int64(A, B)
    ymm1 = _mm256_load_si256((__m256i*) & demo_int16[0]); // ymm1=int64(C, D)
    ymm3 = _mm256_permute2x128_si256(ymm0, ymm1, 0x20); // 20h={2,0}. ymm3=int64(A, C)
    ymm2 = _mm256_permute2x128_si256(ymm0, ymm1, 0x31); // 31h={3,1}. ymm3=int64(B, D)
    ymm3 = _mm256_slli_epi16(ymm3, 8);
    ymm3 = _mm256_srli_epi16(ymm3, 8);
    ymm2 = _mm256_slli_epi16(ymm2, 8);
    ymm2 = _mm256_srli_epi16(ymm2, 8);
    ymm0 = _mm256_packus_epi16(ymm3, ymm2);

    // done.
    printf("Narrow_Int16:\t%d\n", ymm0.m256i_i8[0]);
}

void testX86Avx() {
    int i;
    printf("[testX86Avx]\n");

    // init.
    for (i = 0; i < 32; ++i) {
        if (i < (sizeof(demo_int8) / sizeof(demo_int8[0]))) {
            demo_int8[i] = (int8_t)i;
        }
        if (i < (sizeof(demo_int16) / sizeof(demo_int16[0]))) {
            demo_int16[i] = (int16_t)i;
        }
        if (i < (sizeof(demo_int32) / sizeof(demo_int32[0]))) {
            demo_int32[i] = (int32_t)i;
        }
        if (i < (sizeof(demo_int64) / sizeof(demo_int64[0]))) {
            demo_int64[i] = (int64_t)i;
        }
    }
    demo_int8[0] = -128;
    demo_int8[1] = -2;
    demo_int8[2] = 127;
    demo_int8[3] = (int8_t)0xFF;
    demo_int8[4] = 4;
    demo_int8[5] = (int8_t)(1 << 4);
    demo_int16[0] = -32768;
    demo_int16[1] = -2;
    demo_int16[2] = 32767;
    demo_int16[3] = (int16_t)0xFFU;
    demo_int16[4] = 8;
    demo_int16[5] = (int8_t)(1 << 8);
    demo_int32[0] = -2147483648;
    demo_int32[1] = -2;
    demo_int32[2] = 2147483647;
    demo_int32[3] = (int32_t)0xFFFFU;
    demo_int32[4] = 16;
    demo_int32[5] = (int32_t)(1 << 16);
    demo_int64[0] = INT64_C(0x8000000000000000);
    demo_int64[1] = -2L;
    demo_int64[2] = INT64_C(0x7FFFFFFFFFFFFFFF);
    demo_int64[3] = (int64_t)0xFFFFFFFFU;

    // test.
    Narrow_Int16();
    Widen_SByte();
}

