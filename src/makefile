main: fizzbuzzlib.dylib
	export LD_LIBRARY_PATH=.
	g++ test.cpp -o test.out -lfizzbuzz -lfizzbuzzc -L.
	./test.out

fizzbuzzlib.dylib:
	g++ fizzbuzzlib.cpp -o libfizzbuzz.dylib -dynamiclib
	g++ fizzbuzzlibc.cpp -o libfizzbuzzc.dylib -dynamiclib