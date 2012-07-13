main: fizzbuzzlib.dylib
	export LD_LIBRARY_PATH=.
	g++ test.c -o test.out -lfizzbuzz -L.
	./test.out

fizzbuzzlib.dylib:
	g++ fizzbuzzlib.cpp -o libfizzbuzz.dylib -dynamiclib
